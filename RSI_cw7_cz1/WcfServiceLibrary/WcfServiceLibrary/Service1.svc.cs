using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    class MyData
    {
        public static string info()
        {
            var toReturn = "";
            var dateNow = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");
            toReturn += dateNow + "\n";
            toReturn += "Kamila Sproska 254534" + "\n";
            toReturn += Environment.OSVersion.VersionString + "\n";
            toReturn += Environment.UserName + "\n";
            toReturn += Environment.Version.ToString() + "\n";
            toReturn += "IPs:" + "\n";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    toReturn += ip.ToString() + "\n";
                }
            }
            return toReturn;
        }
    }

    public class Service1 : ILibraryService
    {
        private static List<Movie> movies_list = new List<Movie>() {
            new Movie {Id = 100, Title = "What we do int the shadows", Length = 116, Director = "Taika Waititi"},
            new Movie {Id = 101, Title = "But I'm a Cheerleader", Length = 197, Director = "Jamie Babbit"},
            new Movie {Id = 102, Title = "Promising Young Woman", Length = 173, Director = "Emerald Fennell"},
            new Movie {Id = 103, Title = "Happiest season", Length = 153, Director = "Clea DuVall"}
        };

        public string addMoviesXml(Movie item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = item.Id;
            int idx = movies_list.FindIndex(b => b.Id == newIdx);
            if (idx == -1)
            {
                item.Id = newIdx;
                movies_list.Add(item);
                movies_list = movies_list.OrderBy(x => x.Id).ToList();
                return "Added item with ID=" + item.Id;
            }
            else
                return "Id already exists ID=" + item.Id;
        }

        public string deleteMovieXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return "No item with ID=" + Id;
            movies_list.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<Movie> getAllMoviesXml()
        {
            return movies_list;
        }

        public Movie getByIdMoviesXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return movies_list.ElementAt(idx);
        }

        public Movie getByIdNextMovieJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % movies_list.Count();
            return movies_list.ElementAt(idx);
        }

        public DataString getMyData()
        {
            string data = MyData.info();
            return new DataString() { description = data };
        }

        string ILibraryService.addMovieJson(Movie item)
        {
            return addMoviesXml(item);
        }

        string ILibraryService.deleteMovieJson(string Id)
        {
            return deleteMovieXml(Id);
        }

        List<Movie> ILibraryService.getAllMoviesJson()
        {
            return getAllMoviesXml();
        }

        Movie ILibraryService.getByIdMoviesJson(string Id)
        {
            return getByIdMoviesXml(Id);
        }
    }
}
