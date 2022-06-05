using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILibraryService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/movies")]
        List<Movie> getAllMoviesXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies", ResponseFormat = WebMessageFormat.Json)]
        List<Movie> getAllMoviesJson();

        [OperationContract]
        [WebGet(UriTemplate = "/movies/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Movie getByIdMoviesXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies/{id}", ResponseFormat = WebMessageFormat.Json)]
        Movie getByIdMoviesJson(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Movie getByIdNextMovieJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/movies", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addMoviesXml(Movie item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string addMovieJson(Movie item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/movies/{id}", Method = "DELETE")] 
        string deleteMovieXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)] 
        string deleteMovieJson(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/mydata", ResponseFormat = WebMessageFormat.Json)]
        DataString getMyData();

        //Book
        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> getAllBooksXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books", ResponseFormat = WebMessageFormat.Json)]
        List<Book> getAllBooksJson();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Book getByIdBooksXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book getByIdBooksJson(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book getByIdNextBookJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addBooksXml(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string addBookJson(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE")] 
        string deleteBookXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)] 
        string deleteBookJson(string Id);

        //Music
        [OperationContract]
        [WebGet(UriTemplate = "/musics")]
        List<Music> getAllMusicsXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/musics", ResponseFormat = WebMessageFormat.Json)]
        List<Music> getAllMusicsJson();

        [OperationContract]
        [WebGet(UriTemplate = "/musics/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Music getByIdMusicsXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/musics/{id}", ResponseFormat = WebMessageFormat.Json)]
        Music getByIdMusicsJson(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/musics/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Music getByIdNextMusicJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/musics", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addMusicsXml(Music item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/musics", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string addMusicJson(Music item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/musics/{id}", Method = "DELETE")]
        string deleteMusicXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/musics/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string deleteMusicJson(string Id);
    }


    [DataContract]
    public class Movie
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public int Length { get; set; }

        [DataMember(Order = 2)]
        public string Director { get; set; }
    }

    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Genre { get; set; }

        [DataMember(Order = 3)]
        public string Author { get; set; }
    }

    [DataContract]
    public class Music
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Genre { get; set; }

        [DataMember(Order = 3)]
        public string Author { get; set; }

        [DataMember(Order = 4)]
        public float Length { get; set; }
    }

    [DataContract]
    public class DataString
    {
        [DataMember(Order = 0)]
        public string description { get; set; }

    }
}
