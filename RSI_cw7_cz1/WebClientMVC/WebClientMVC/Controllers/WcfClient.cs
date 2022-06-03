using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebClientMVC.Models;
using Nancy.Json;
using Newtonsoft.Json.Serialization;

namespace WebClientMVC.Controllers
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var serializerSettings = new JsonSerializerSettings();
            //serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //var serialized = JsonConvert.SerializeObject(obj, serializerSettings);
            //return serialized;
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //return serializer.Serialize(obj);
            return JsonConvert.SerializeObject(obj);
        }
    }

    public class WcfClient
    {
        private static string baseWebHttp = "http://localhost:52680/Service1.svc/json/movies";
        public static string getAllCurrentItems()
        {
            HttpWebRequest req = WebRequest.Create(baseWebHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }
        public static List<Movie> getItems()
        {
            var toReturn = new List<Movie>();
            var inputJson = getAllCurrentItems();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            foreach (DataRow dataRow in dt.Rows)
            {
                
                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Director = dataRow.ItemArray[2].ToString();
                var Length = int.Parse(dataRow.ItemArray[3].ToString());
                var movieItem = new Movie(Id, Title, Length, Director);

                toReturn.Add(movieItem);
            }
            return toReturn;
        }

        public static string postNewItem(Movie movie)
        {
            string jsonFile = JSONHelper.ToJSON(movie);
            System.Diagnostics.Debug.WriteLine(jsonFile);
            HttpWebRequest req = WebRequest.Create(baseWebHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = "application/json";

            byte[] bufor = Encoding.UTF8.GetBytes(jsonFile);
            req.ContentLength = bufor.Length;
            Stream postData = req.GetRequestStream();
            postData.Write(bufor, 0, bufor.Length);
            postData.Close();

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        public static string deleteId(int id)
        {
            HttpWebRequest req = WebRequest.Create(baseWebHttp + "/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "DELETE";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        public static void editId(Movie movie)
        {
            deleteId(movie.Id);
            postNewItem(movie);
        }

        public static string getNext(int id)
        {
            HttpWebRequest req = WebRequest.Create(baseWebHttp + "/next/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "GET";
            req.ContentType = "application/json";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }
    }
}
