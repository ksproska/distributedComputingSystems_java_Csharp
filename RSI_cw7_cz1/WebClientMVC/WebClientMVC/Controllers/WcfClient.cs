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
        private static string dataWebHttp = "http://localhost:52680/Service1.svc/mydata";
        private static string bookWebHttp = "http://localhost:52680/Service1.svc/json/books";
        private static string musicWebHttp = "http://localhost:52680/Service1.svc/json/musics";

        public static string getMyData()
        {
            HttpWebRequest req = WebRequest.Create(dataWebHttp) as HttpWebRequest;
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

            dynamic stuff1 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
            return stuff1["description"];

            return responseString;
        }
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
            //System.Diagnostics.Debug.WriteLine(jsonFile);
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

        //Book
        public static string getAllCurrentBooks()
        {
            HttpWebRequest req = WebRequest.Create(bookWebHttp) as HttpWebRequest;
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
        public static List<Book> getBooks()
        {
            var toReturn = new List<Book>();
            var inputJson = getAllCurrentBooks();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Genre = dataRow.ItemArray[2].ToString();
                var Author = dataRow.ItemArray[3].ToString();
                var bookItem = new Book(Id, Title, Genre, Author);

                toReturn.Add(bookItem);
            }
            return toReturn;
        }


        public static string postNewBook(Book book)
        {
            string jsonFile = JSONHelper.ToJSON(book);
            //System.Diagnostics.Debug.WriteLine(jsonFile);
            HttpWebRequest req = WebRequest.Create(bookWebHttp) as HttpWebRequest;
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

        public static string deleteIdBook(int id)
        {
            HttpWebRequest req = WebRequest.Create(bookWebHttp + "/" + id) as HttpWebRequest;
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

        public static void editIdBook(Book book)
        {
            deleteIdBook(book.Id);
            postNewBook(book);
        }

        public static string getNextBook(int id)
        {
            HttpWebRequest req = WebRequest.Create(bookWebHttp + "/next/" + id) as HttpWebRequest;
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


        //Music
        public static string getAllCurrentMusics()
        {
            HttpWebRequest req = WebRequest.Create(musicWebHttp) as HttpWebRequest;
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
        public static List<Music> getMusics()
        {
            var toReturn = new List<Music>();
            var inputJson = getAllCurrentMusics();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Genre = dataRow.ItemArray[2].ToString();
                var Author = dataRow.ItemArray[3].ToString();
                var Length = float.Parse(dataRow.ItemArray[4].ToString());
                var musicItem = new Music(Id, Title, Genre, Author, Length);

                toReturn.Add(musicItem);
            }
            return toReturn;
        }


        public static string postNewMusic(Music music)
        {
            string jsonFile = JSONHelper.ToJSON(music);
            //System.Diagnostics.Debug.WriteLine(jsonFile);
            HttpWebRequest req = WebRequest.Create(musicWebHttp) as HttpWebRequest;
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

        public static string deleteIdMusic(int id)
        {
            HttpWebRequest req = WebRequest.Create(musicWebHttp + "/" + id) as HttpWebRequest;
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

        public static void editIdMusic(Music music)
        {
            deleteIdMusic(music.Id);
            postNewMusic(music);
        }

        public static string getNextMusic(int id)
        {
            HttpWebRequest req = WebRequest.Create(musicWebHttp + "/next/" + id) as HttpWebRequest;
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
