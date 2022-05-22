using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //[ServiceContract]
    //public interface IService1
    //{

    //    [OperationContract]
    //    string GetData(int value);

    //    [OperationContract]
    //    CompositeType GetDataUsingDataContract(CompositeType composite);

    //    // TODO: Add your service operations here
    //}


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

    // Zdefiniuj kontrakt serwisu
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Book getByIdXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addXml(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE")] //"Xxx{id}"
        string deleteXml(string Id);
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
