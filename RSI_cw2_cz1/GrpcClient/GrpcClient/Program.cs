using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
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

        static async Task Main(string[] args)
        {
            MyData.info();
            Console.WriteLine("\nStarting gRPC Client");
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new GrpcService.GrpcServiceClient(channel);
            Console.Write("Enter the name: ");
            String str = Console.ReadLine();
            Console.Write("Enter age: ");
            int val = Int32.Parse(Console.ReadLine());
            var reply = await client.GrpcProcAsync(new GrpcRequest
            {
                Name = str,
                Age = val
            });
            Console.WriteLine("From server: " + reply.Message);
            Console.WriteLine("From server: " + val + " years = " + reply.Days + " days");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
