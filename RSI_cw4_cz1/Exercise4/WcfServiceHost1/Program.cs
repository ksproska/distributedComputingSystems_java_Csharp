using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using WcfService1;
using System.ServiceModel.Description;
using System.Net;
using System.Net.Sockets;

namespace WcfServiceHost1
{
    class MyData
    {
        public static void info()
        {
            var dateNow = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");
            Console.WriteLine(dateNow);
            Console.WriteLine("Marta Kuchciak 254568");
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

            // Step 1 Create the URI of service base address
            // Instead of xxx enter port number of value: 10000 + workstation
            // Instead of the BaseName (service name), enter your own name of the service
            // Uri baseAddress = new Uri("http://localhost:xxx/BaseName");
            Uri baseAddress = new Uri("http://localhost:10014/BaseName");

            // Step 2 Create service instance.
            ServiceHost myHost = new ServiceHost(typeof(MyCalculator), baseAddress);

            // Step 3 Add the endpoint
            BasicHttpBinding myBinding = new BasicHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(ICalculator), myBinding, "endpoint1");

            // Step 4 Set up metadata and publish service metadata
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);

            // Step 4.5 - exercise 12
            WSHttpBinding binding2 = new WSHttpBinding();
            binding2.Security.Mode = SecurityMode.None;
            ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(typeof(ICalculator), binding2, "endpoint2");

           
            Console.WriteLine("\n---> Endpoints:");
            // copy below code for each endpoint:
            Console.WriteLine("Service endpoint {0}:", endpoint1.Name);
            Console.WriteLine("Binding {0}:", endpoint1.Binding.ToString());
            Console.WriteLine("ListenUri {0}:", endpoint1.ListenUri.ToString());
            Console.WriteLine("Service endpoint {0}:", endpoint2.Name);
            Console.WriteLine("Binding {0}:", endpoint2.Binding.ToString());
            Console.WriteLine("ListenUri {0}:", endpoint2.ListenUri.ToString());

            // Step 5 Run the service.
            try
            {
                myHost.Open();
                Console.WriteLine("-->Service started.");
                Console.WriteLine("-->Press <ENTER> to STOP service...");
                Console.WriteLine();
                Console.ReadLine(); // to not finish app immediately:
                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("-->Exception occured: {0}", ce.Message);
                myHost.Abort();
            }
        }
    }
}
