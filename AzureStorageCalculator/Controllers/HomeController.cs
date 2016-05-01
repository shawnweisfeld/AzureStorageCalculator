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
            vm.AtRestPrices = new List<AtRestPrice>()
            {
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.01
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.024
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.02
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.048
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.025
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 100000,
                    Amount = 0.061
                },


                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.01
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.0232
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.02
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.0463
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.025
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 900000,
                    Amount = 0.0589
                },


                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.01
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.0223
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.02
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.0446
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Cool,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.025
                },
                new AtRestPrice()
                {
                    StorageTemperature = StorageTemperature.Hot,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    SizeCutoff = 4000000,
                    Amount = 0.05670
                },

            };

            

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