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
                Console.WriteLine("Kamila Sproska 254534!");
                Console.WriteLine(Environment.UserName);
                Console.WriteLine(Environment.OSVersion.VersionString);
                Console.WriteLine("\n");

                //Process p = new Process();
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.FileName = "java.exe";
                //p.StartInfo.Arguments = "-version";
                //p.Start();
                //string output = p.StandardOutput.ReadToEnd();
                //p.WaitForExit();
                //Console.WriteLine(output);

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
