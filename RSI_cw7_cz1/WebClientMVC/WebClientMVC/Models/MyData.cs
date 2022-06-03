using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebClientMVC.Models
{
    public class MyData
    {
        public MyData() { }
        public string InfoClient { get; set; }
        public string InfoService { get; set; }
    }
}
