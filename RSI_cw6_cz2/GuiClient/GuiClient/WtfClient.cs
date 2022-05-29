using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuiClient
{
    class WtfClient
    {
        private static string baseWebHttp = "http://localhost:61905/MoviesService.svc/json/movies";
        private static int padding = 30;
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

        public static string getPrettyNames()
        {
            var inputJson = getAllCurrentItems();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            //var toReturn = "All avaliable: " + dt.Rows.Count + "\r\n\r\n";
            var toReturn = "";
            foreach (DataColumn c in dt.Rows[0].Table.Columns)
            {
                toReturn += c.ColumnName.ToString().PadRight(padding);
            }
            //toReturn += "\r\n";

            //foreach (DataRow dataRow in dt.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        toReturn += item.ToString().PadRight(padding);
            //    }
            //    toReturn += "\r\n";
            //}
            return toReturn;
        }

        public static List<String> getItems()
        {
            var toReturn = new List<String>();
            var inputJson = getAllCurrentItems();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            foreach (DataRow dataRow in dt.Rows)
            {
                var itemText = "";
                foreach (var item in dataRow.ItemArray)
                {
                    itemText += item.ToString().PadRight(padding);
                }
                toReturn.Add(itemText);
            }
            return toReturn;
        }
    }
}
