using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class MyDataController : Controller
    {
        public static string info()
        {
            var toReturn = "";
            var dateNow = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss");
            toReturn += dateNow + "\n";
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
        public IActionResult Index()
        {
            var myData = new MyData();
            myData.InfoClient = info();
            try
            {
                myData.InfoService = WcfClient.getMyData();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return View("ServiceNotRunning");
            }
            return View(myData);
        }
    }
}
