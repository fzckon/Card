using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using NLog;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //public static Logger logger = LogManager.GetCurrentClassLogger();
        public static Logger logger1 = LogManager.GetLogger("Trace");
        public static Logger logger2 = LogManager.GetLogger("aaa");
        public IActionResult Index()
        {
            //var a = LogManager.DefaultCultureInfo;
            //var c = LogManager.LogFactory;
            //logger1.Warn("Test1-Warn");
            //logger1.Trace("Test1-Trace");
            //logger1.Info("Test1-Info");
            //logger1.Error("Test1-Error");
            //logger1.Debug("Test1-Debug");
            //logger1.Fatal("Test1-Fatal");

            //logger2.Warn("Test2-Warn");
            //logger2.Trace("Test2-Trace");
            //logger2.Info("Test2-Info");
            //logger2.Error("Test2-Error");
            //logger2.Debug("Test2-Debug");
            //logger2.Fatal("Test2-Fatal");


            //logger.Warn("Test-Warn");
            //logger.Trace("Test-Trace");
            //logger.Info("Test-Info");
            //logger.Error("Test-Error");
            //logger.Debug("Test-Debug");
            //logger.Fatal("Test-Fatal");

            Common.Utils.Logger.Default.Error("Test3-Error");
            Common.Utils.Logger.Factory("Trace").Error("Test4-Error");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
