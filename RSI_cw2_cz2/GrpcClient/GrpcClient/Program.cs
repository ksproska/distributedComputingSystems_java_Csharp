using Grpc.Net.Client;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
//using GrpcServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nStarting gRPC Client");
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new ShapesAnalyzer.ShapesAnalyzerClient(channel);
            var triangle = new TriangleSides
            {
                A = 5.0,
                B = 3.0,
                C = 4.0
            };
            var reply = await client.GetTriangleSurfaceAsync(triangle);
            Console.WriteLine("Triangle with sides a="
                + triangle.A + "; b=" + triangle.B + "; c=" + triangle.C + " has size " + reply.Size);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
