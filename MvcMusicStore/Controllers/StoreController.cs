using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        public string Index(string id = "")
        {
            return $"Hello from Store.Index():{id}";
        }
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        public string Details()
        {
            return "Hello from Store.Details()";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}