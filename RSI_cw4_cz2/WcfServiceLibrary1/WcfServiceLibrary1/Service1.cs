using System;
using System.ServiceModel;
using System.Threading;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AsyncService : IAsyncService
    {
        void IAsyncService.Fun1(string s1)
        {
            Console.WriteLine("...called Fun 1 - start");
            Thread.Sleep(4 * 1000);   // sleep for 4 sec. (4000 ms) 
            Console.WriteLine("...Fun 1 - stop");
            return;
        }

        void IAsyncService.Fun2(string s2)
        {
            Console.WriteLine("...called Fun 2 - start ");
            Thread.Sleep(2 * 1000);   // sleep for 2 sec. (2000 ms) 
            Console.WriteLine("...Fun 2 - stop");
            return;
        }
    }
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
