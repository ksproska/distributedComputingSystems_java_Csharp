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
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("HW");
        //}

        public static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintGreen(string message)
        {
            PrintColored(message, ConsoleColor.Green);
        }
        public static void PrintMagenta(string message)
        {
            PrintColored(message, ConsoleColor.Magenta);
        }
        public static void PrintRed(string message)
        {
            PrintColored(message, ConsoleColor.Red);
        }

        static async Task Main(string[] args)
        {
            PrintGreen("Starting gRPC Client\n");
            try
            {
                using var channel = GrpcChannel.ForAddress("http://localhost:5000");
                var client = new ShapesAnalyzer.ShapesAnalyzerClient(channel);

                var triangle = new TriangleSides
                {
                    A = 5.0,
                    B = 3.0,
                    C = 4.0
                };
                var replyTriangleSurface = await client.GetTriangleSurfaceAsync(triangle);
                Console.WriteLine("Triangle with sides " + triangle.ToString() + " has size " + replyTriangleSurface.Size);
                var replayIsRight = await client.IsTriangleRightAngleAsync(triangle);
                Console.WriteLine("Triangle with sides " + triangle.ToString() + " is right: " + replayIsRight.Message);

                PrintGreen("\nPress any key to exit...");

                Console.ReadKey();
                channel.ShutdownAsync().Wait();
            }
            catch (Grpc.Core.RpcException)
            {
                PrintRed("SERVER NOT RUNNING!");
            }
            
        }
    }
}
