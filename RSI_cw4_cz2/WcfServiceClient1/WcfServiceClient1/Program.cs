using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient1.ServiceReference1;
//using WcfServiceClient1.ServiceReference1;

namespace WcfServiceClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client1 = new WcfServiceClient1.ServiceReference1.ComplexCalcClient("WSHttpBinding_IComplexCalc");
            var cnum1 = new ComplexNum();
            cnum1.real = 1.2;
            cnum1.imag = 3.4;
            var cnum2 = new ComplexNum();
            cnum2.real = 5.6;
            cnum2.imag = 7.8;
            Console.WriteLine("\nCLIENT1 - START");
            Console.WriteLine("...calling addCNum(...)");
            ComplexNum result1 = client1.addCNum(cnum1, cnum2);
            Console.WriteLine(" addCNum(...) = ({0},{1})",
                           result1.real, result1.imag);
            Console.WriteLine("--> Press ENTER to continue");
            Console.ReadLine();
            client1.Close();
            Console.WriteLine("CLIENT1 - STOP");
        }
    }
}
