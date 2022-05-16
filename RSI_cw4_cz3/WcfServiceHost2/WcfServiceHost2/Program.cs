using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceLibrary2;

namespace WcfServiceHost2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress1 = new Uri("http://localhost:10015/Movies");
            Uri baseAddress11 = new Uri("http://localhost:10015/MoviesCallback");
            //Uri baseAddress2 = new Uri("http://localhost:10015/Books");
            //Uri baseAddress3 = new Uri("http://localhost:10017/BaseName");
            ServiceHost myHost1 = new ServiceHost(typeof(MovieHandler), baseAddress1);
            ServiceHost myHost11 = new ServiceHost(typeof(MovieHandlerCallback), baseAddress11);
            //ServiceHost myHost2 = new ServiceHost(typeof(BookHandler), baseAddress2);
            //ServiceHost myHost3 = new ServiceHost(typeof(MySuperCalc), baseAddress3);
            WSHttpBinding myBinding = new WSHttpBinding();
            WSDualHttpBinding myBinding2 = new WSDualHttpBinding();
            ServiceEndpoint endpoint1 = myHost1.AddServiceEndpoint(typeof(IMovieHandler), myBinding, "movies");
            ServiceEndpoint endpoint11 = myHost11.AddServiceEndpoint(typeof(IMovieHandlerCallback), myBinding2, "moviesCallback");
            //ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IBookHandler), myBinding2, "books");
            //ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISuperCalc), myBinding2, "endpoint3");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);
            myHost11.Description.Behaviors.Add(smb);
            //myHost2.Description.Behaviors.Add(smb);
            //myHost3.Description.Behaviors.Add(smb);
            try
            {
                myHost1.Open();
                myHost11.Open();
                Console.WriteLine("--> MovieHandler is running.");
                //myHost2.Open();
                Console.WriteLine("--> BookHandler is running");
                //myHost3.Open();
                //Console.WriteLine("--> Callback SuperCalc is running.");

                Console.WriteLine("--> Press <ENTER> to stop.\n");
                Console.ReadLine();
                myHost1.Close();
                myHost11.Close();
                Console.WriteLine("--> MovieHandler finished");
                //myHost2.Close();
                Console.WriteLine("--> BookHandler finished");
                //myHost3.Close();
                //Console.WriteLine("--> Callback SuperCalc finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occurred: {0}", ce.Message);
                myHost1.Abort();
                myHost11.Abort();
                //myHost2.Abort();
                //myHost3.Abort();
            }
        }
    }
}
