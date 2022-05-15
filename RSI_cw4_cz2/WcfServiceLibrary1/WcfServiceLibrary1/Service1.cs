using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    public class MyComplexCalc : IComplexCalc
    {
        public ComplexNum addCNum(ComplexNum n1, ComplexNum n2)
        {
            Console.WriteLine("...called addCNum(...)");
            return new ComplexNum(n1.real + n2.real,
                               n1.imag + n2.imag);
        }
    }
}
