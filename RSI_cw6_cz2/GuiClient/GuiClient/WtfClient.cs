using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GuiClient
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }
    public class Movie
    {
        private static int IdPadding = 5;
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }

        public override string ToString()
        {
            var toReturn = Id.ToString().PadRight(IdPadding);
            foreach(var item in new List<Object> { Title, Director, Length })
            {
                toReturn += item.ToString().PadRight(WtfClient.padding);
            }
            return toReturn;
        }

        public static string getTitles()
        {
            var toReturn = "Id".PadRight(IdPadding);
            foreach (var item in new List<string> { "Title", "Director", "Length" })
            {
                toReturn += item.PadRight(WtfClient.padding);
            }
            return toReturn;
        }
    }
    class WtfClient
    {
        private static string baseWebHttp = "http://localhost:61905/MoviesService.svc/json/movies";
        public static int padding = 30;
        public static string getAllCurrentItems()
        {
            HttpWebRequest req = WebRequest.Create(baseWebHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
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

        public static string postNewItem(Movie movie)
        {
            string jsonFile = JSONHelper.ToJSON(movie);
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
                var movieItem = new Movie();
                movieItem.Id = int.Parse(dataRow.ItemArray[0].ToString());
                movieItem.Title = dataRow.ItemArray[1].ToString();
                movieItem.Director = dataRow.ItemArray[2].ToString();
                movieItem.Length = int.Parse(dataRow.ItemArray[3].ToString());
                
                
                toReturn.Add(movieItem);
            }
            return toReturn;
        }
    }
}
