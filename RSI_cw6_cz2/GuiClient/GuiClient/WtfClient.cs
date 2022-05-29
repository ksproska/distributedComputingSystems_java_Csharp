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

        public static string getPretty(string inputJson)
        {
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);
            var toReturn = "All avaliable: " + dt.Rows.Count + "\r\n\r\n";

            foreach (DataColumn c in dt.Rows[0].Table.Columns)
            {
                toReturn += c.ColumnName.ToString().PadRight(padding);
            }
            toReturn += "\r\n";

            foreach (DataRow dataRow in dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    toReturn += item.ToString().PadRight(padding);
                }
                toReturn += "\r\n";
            }
            return toReturn;
        }

        public static string getAllCurrentItemsPretty()
        {
            var inputJson = getAllCurrentItems();
            return getPretty(inputJson);
        }
    }
}
