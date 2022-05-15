using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient1.ServiceReference1;

namespace WcfServiceClient1
{
    [ServiceContract]
    public interface IComplexCalc
    {
        [OperationContract]
        ComplexNum addCNum(ComplexNum n1, ComplexNum n2);
    }

    //[DataContract]
    //public class ComplexNum
    //{
    //    string description = "Complex number";
    //    [DataMember]
    //    public double real;
    //    [DataMember]
    //    public double imag;
    //    [DataMember]
    //    public string Desc
    //    {
    //        get { return description; }
    //        set { description = value; }
    //    }
    //    public ComplexNum(double r, double i)
    //    {
    //        this.real = r;
    //        this.imag = i;
    //    }
    //}
}