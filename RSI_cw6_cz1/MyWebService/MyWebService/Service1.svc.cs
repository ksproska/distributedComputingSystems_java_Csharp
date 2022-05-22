using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    //public class Service1 : IService1
    //{
    //    public string GetData(int value)
    //    {
    //        return string.Format("You entered: {0}", value);
    //    }

    //    public CompositeType GetDataUsingDataContract(CompositeType composite)
    //    {
    //        if (composite == null)
    //        {
    //            throw new ArgumentNullException("composite");
    //        }
    //        if (composite.BoolValue)
    //        {
    //            composite.StringValue += "Suffix";
    //        }
    //        return composite;
    //    }
    //}

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IRestService
    {
        private static List<Book> books_list = new List<Book>() {
            new Book {Id = 100, Title = "Dziady", Price = 32.55},
            new Book {Id = 101, Title = "Potop", Price = 15.00},
            new Book {Id = 102, Title = "Balladyna", Price = 42.90}
        };

        public string addXml(Book item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = item.Id;
            int idx = books_list.FindIndex(b => b.Id == newIdx);
            if (idx == -1)
            {
                item.Id = newIdx;
                books_list.Add(item);
                return "Added item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict", System.Net.HttpStatusCode.Conflict);
        }

        public string deleteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = books_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            books_list.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<Book> getAllXml()
        {
            return books_list;
        }

        public Book getByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = books_list.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            return books_list.ElementAt(idx);
        }
    }
}
