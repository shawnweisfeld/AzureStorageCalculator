using AzureStorageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureStorageCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new ViewModels.Home.Index();
            vm.AtRestPrices = AtRestPrice.GetDefault();
            vm.OtherPrices = OtherPrice.GetDefault();
            return View(vm);
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