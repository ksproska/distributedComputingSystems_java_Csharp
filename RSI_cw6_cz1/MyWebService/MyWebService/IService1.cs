using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // Zdefiniuj kontrakt serwisu
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books", ResponseFormat = WebMessageFormat.Json)]
        List<Book> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Book getByIdXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book getByIdJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addXml(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string addJson(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE")] //"Xxx{id}"
        string deleteXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)] //"Xxx{id}"
        string deleteJson(string Id);
    }

    // Zdefiniuj kontrakt danych
    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public double Price { get; set; }
    }
}
