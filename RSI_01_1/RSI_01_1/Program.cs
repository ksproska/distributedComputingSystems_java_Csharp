using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace RSI_01_1
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
        static void Main(string[] args)
        {
            MyData.info();
        }
    }
}
