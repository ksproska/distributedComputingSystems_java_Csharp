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
        private static List<Movie> movies_list = new List<Movie>() 
        {
            new Movie {Id = 100, Title = "What we do int the shadows", Length = 116, Director = "Taika Waititi"},
            new Movie {Id = 101, Title = "But I'm a Cheerleader", Length = 197, Director = "Jamie Babbit"},
            new Movie {Id = 102, Title = "Promising Young Woman", Length = 173, Director = "Emerald Fennell"},
            new Movie {Id = 103, Title = "Happiest season", Length = 153, Director = "Clea DuVall"}
        };

        private static List<Book> books_list = new List<Book>() 
        {
            new Book {Id = 200, Title = "Sparring Partners", Genre = "Crime", Author = "John Grisham"},
            new Book {Id = 201, Title = "Where the Crawdads Sing", Genre = "Literary fiction", Author = "Delia Owens"},
            new Book {Id = 202, Title = "Nornal People", Genre = "Novel", Author = "Sally Rooney"}
        };

        private static List<Music> musics_list = new List<Music>
        {
            new Music {Id = 300, Title = "Mount Everest", Genre = "Pop", Author = "Labrinth", Length = 2.37F},
            new Music {Id = 301, Title = "As It Was", Genre = "Pop", Author = "Harry Styles", Length = 2.47F},
            new Music {Id = 302, Title = "Walkin", Genre = "Rap", Author = "Denzel Curry", Length = 4.40F},
        };

        public string addBookJson(Book item)
        {
            return addBooksXml(item);
        }

        public string addBooksXml(Book item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = item.Id;
            int idx = books_list.FindIndex(b => b.Id == newIdx);
            if (idx == -1)
            {
                item.Id = newIdx;
                books_list.Add(item);
                books_list = books_list.OrderBy(x => x.Id).ToList();
                return "Added item with ID=" + item.Id;
            }
            else
                return "Id already exists ID=" + item.Id;
        }

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

        public string addMusicJson(Music item)
        {
            return addMusicsXml(item);
        }

        public string addMusicsXml(Music item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = item.Id;
            int idx = musics_list.FindIndex(b => b.Id == newIdx);
            if (idx == -1)
            {
                item.Id = newIdx;
                musics_list.Add(item);
                musics_list = musics_list.OrderBy(x => x.Id).ToList();
                return "Added item with ID=" + item.Id;
            }
            else
                return "Id already exists ID=" + item.Id;
        }

        public string deleteBookJson(string Id)
        {
            return deleteBookXml(Id);
        }

        public string deleteBookXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = books_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return "No item with ID=" + Id;
            books_list.RemoveAt(idx);
            return "Removed item with ID=" + Id;
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

        public string deleteMusicJson(string Id)
        {
            return deleteMusicXml(Id);
        }

        public string deleteMusicXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = musics_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return "No item with ID=" + Id;
            musics_list.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<Book> getAllBooksJson()
        {
            return getAllBooksXml();
        }

        public List<Book> getAllBooksXml()
        {
            return books_list;
        }

        public List<Movie> getAllMoviesXml()
        {
            return movies_list;
        }

        public List<Music> getAllMusicsJson()
        {
            return getAllMusicsXml();
        }

        public List<Music> getAllMusicsXml()
        {
            return musics_list;
        }

        public Book getByIdBooksJson(string Id)
        {
            return getByIdBooksXml(Id);
        }

        public Book getByIdBooksXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = books_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return books_list.ElementAt(idx);
        }

        public Movie getByIdMoviesXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = movies_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return movies_list.ElementAt(idx);
        }

        public Music getByIdMusicsJson(string Id)
        {
            return getByIdMusicsXml(Id);
        }

        public Music getByIdMusicsXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = musics_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return musics_list.ElementAt(idx);
        }

        public Book getByIdNextBookJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = books_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % books_list.Count();
            return books_list.ElementAt(idx);
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

        public Music getByIdNextMusicJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = musics_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % musics_list.Count();
            return musics_list.ElementAt(idx);
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
