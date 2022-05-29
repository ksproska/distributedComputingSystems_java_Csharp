using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GuiClient
{
    class MyData
    {
        public static string info()
        {
            var toReturn = "";
            var dateNow = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");
            toReturn += dateNow + "\n";
            toReturn += "Kamila Sproska 254534" + "\n";
            toReturn += "Marta Kuchciak 254568" + "\n";
            toReturn += Environment.OSVersion.VersionString + "\n";
            toReturn += Environment.UserName + "\n";
            toReturn += Environment.Version.ToString() + "\n";
            toReturn += "IPs:" + "\n";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    toReturn += ip.ToString() + "\n";
                }
            }
            return toReturn;
        }
    }
}
