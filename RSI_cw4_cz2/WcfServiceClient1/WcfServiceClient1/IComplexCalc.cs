using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WcfServiceClient1.ServiceReference1;

namespace WcfServiceClient1
{
    [ServiceContract]
    public interface IComplexCalc
    {
        [OperationContract]
        ComplexNum addCNum(ComplexNum n1, ComplexNum n2);
    }

    [ServiceContract]
    public interface IAsyncService
    {
        [OperationContract(IsOneWay = true)]
        void Fun1(String s1);
        [OperationContract]
        void Fun2(String s2);
    }
}