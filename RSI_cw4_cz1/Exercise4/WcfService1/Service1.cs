using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyCalculator : ICalculator
    {
        double sum = 0;
        public double Add(double val1, double val2)
        {
            double result = val1 + val2;
            Console.WriteLine("Called: Add(" + val1.ToString() + ", " + val2.ToString() + ")");
            Console.WriteLine("Returned: " + result.ToString());
            return result;
        }
        public double Sub(double val1, double val2)
        {
            double result = val1 - val2;
            Console.WriteLine("Called: Sub(" + val1.ToString() + ", " + val2.ToString() + ")");
            Console.WriteLine("Returned: " + result.ToString());
            return result;
        }
        public double Multiply(double val1, double val2)
        {
            double result = val1 * val2;
            Console.WriteLine("Called: Multiply(" + val1.ToString() + ", " + val2.ToString() + ")");
            Console.WriteLine("Returned: " + result.ToString());
            return result;
        }

        public double Summarize(double n1)
        {
            sum += n1;
            return sum;
        }
    }
}
