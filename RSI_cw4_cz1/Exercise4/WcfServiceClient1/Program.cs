using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient1.ServiceReference1;

namespace WcfServiceClient1
{
    class MyData
    {
        public static void info()
        {
            var dateNow = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");
            Console.WriteLine(dateNow);
            Console.WriteLine("Kamila Sproska 254534");
            Console.WriteLine(Environment.OSVersion.VersionString);
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.Version.ToString());
            Console.WriteLine("IPs:");

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyData.info();
            Console.WriteLine("... The client is started");

            // VERSION 1
            /*// Step 1: Create client proxy based on communication channel.
            // base address;
            Uri baseAddress;

            *//* using channel: *//*
            // binding:
            BasicHttpBinding myBinding = new BasicHttpBinding();
            baseAddress = new Uri("http://localhost:10014/BaseName/endpoint1");

            // endpoint:
            EndpointAddress eAddress = new EndpointAddress(baseAddress);

            // channel factory:
            ChannelFactory<ICalculator> myCF = new ChannelFactory<ICalculator>(myBinding, eAddress);

            // client proxy (here myClient) based on channel
            ICalculator myClient = myCF.CreateChannel();

            // Step 2: service operations call.
            Console.WriteLine("...calling add");
            double result1 = myClient.Add(-3.7, 9.5); //just example values
            Console.WriteLine("Result = " + result1);

            // here other operations
            Console.WriteLine("...calling sub");
            double result2 = myClient.Sub(-3.7, 9.5); //just example values
            Console.WriteLine("Result = " + result2);

            Console.WriteLine("...calling multiply");
            double result3 = myClient.Multiply(-3.7, 9.5); //just example values
            Console.WriteLine("Result = " + result3);

            Console.WriteLine("...press <ENTER> to STOP client...");
            Console.WriteLine();
            Console.ReadLine(); // to not finish app immediately:

            // Step 3: Closing the client - closes connection and clears resources.
            ((IClientChannel)myClient).Close();
            Console.WriteLine("...Client closed - FINISHED");*/


            // VERSION 2
            /*// Step 1: Create client proxy
            CalculatorClient myClient = new CalculatorClient();

            // Step 2: service operation call.
            Console.WriteLine("...calling add2");
            double result1 = myClient.Add(-3.7, 9.5); 
            Console.WriteLine("Result = " + result1);

            // here other operations
            Console.WriteLine("...calling sub2");
            double result2 = myClient.Sub(-3.7, 9.5); 
            Console.WriteLine("Result = " + result2);

            Console.WriteLine("...calling multiply2");
            double result3 = myClient.Multiply(-3.7, 9.5); 
            Console.WriteLine("Result = " + result3);

            // Step 3: Closing the client
            myClient.Close();
            Console.WriteLine("...Client closed - FINISHED");*/


            // VERSION 3
            CalculatorClient client1 = new CalculatorClient("WSHttpBinding_ICalculator");
            CalculatorClient client2 = new CalculatorClient("BasicHttpBinding_ICalculator");
            

            Console.WriteLine("...calling add for client1");
            double result1 = client1.Add(-3.7, 9.5);
            Console.WriteLine("Result = " + result1);
            Console.WriteLine("...calling sub for client1");
            double result2 = client1.Sub(-3.7, 9.5);
            Console.WriteLine("Result = " + result2);
            Console.WriteLine("...calling multiply for client1");
            double result3 = client1.Multiply(-3.7, 9.5);
            Console.WriteLine("Result = " + result3);
            Console.WriteLine("...calling summarize for client1");
            double result4 = client1.Summarize(result1);
            Console.WriteLine("Summary = " + result4);

            Console.WriteLine("...calling add for client2");
            double result5 = client2.Add(-3.7, 9.5);
            Console.WriteLine("Result = " + result5);
            Console.WriteLine("...calling sub for client2");
            double result6 = client2.Sub(-3.7, 9.5);
            Console.WriteLine("Result = " + result6);
            Console.WriteLine("...calling multiply for client2");
            double result7 = client2.Multiply(-3.7, 9.5);
            Console.WriteLine("Result = " + result7);
            Console.WriteLine("...calling summarize for client2");
            double result8 = client2.Summarize(result7);
            Console.WriteLine("Summary = " + result8);

            client1.Close();
            client2.Close();
            Console.WriteLine("...Clients closed - FINISHED");



        }
    }
}
