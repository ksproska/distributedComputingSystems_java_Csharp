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
        [WebInvoke(UriTemplate = "/movies/{id}", Method = "DELETE")] //"Xxx{id}"
        string deleteMovieXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)] //"Xxx{id}"
        string deleteMovieJson(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/mydata", ResponseFormat = WebMessageFormat.Json)]
        DataString getMyData();
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
