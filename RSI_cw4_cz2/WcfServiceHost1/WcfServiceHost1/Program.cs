using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceLibrary1;

namespace WcfServiceHost1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress1 = new Uri("http://localhost:10015/BaseName");
            Uri baseAddress2 = new Uri("http://localhost:10016/BaseName");
            ServiceHost myHost1 = new ServiceHost(typeof(MyComplexCalc), baseAddress1);
            ServiceHost myHost2 = new ServiceHost(typeof(AsyncService), baseAddress2);
            WSHttpBinding myBinding = new WSHttpBinding();
            ServiceEndpoint endpoint1 = myHost1.AddServiceEndpoint(typeof(IComplexCalc), myBinding, "endpoint1");
            ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IAsyncService), myBinding, "endpoint2");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);
            myHost2.Description.Behaviors.Add(smb);
            try
            {
                myHost1.Open();
                Console.WriteLine("--> ComplexCalculator is running.");
                myHost2.Open();
                Console.WriteLine("--> Async service is running");
                Console.WriteLine("--> Press <ENTER> to stop.\n");
                Console.ReadLine();
                myHost1.Close();
                Console.WriteLine("--> ComplexCalculator finished");
                myHost2.Close();
                Console.WriteLine("--> Async service finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occurred: {0}", ce.Message);
                myHost1.Abort();
                myHost2.Abort();
            }
        }
    }
}
