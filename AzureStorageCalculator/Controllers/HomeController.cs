﻿using AzureStorageCalculator.Models;
using OfficeOpenXml;
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

        [HttpPost]
        public ActionResult Calculate(ViewModels.Home.CalculateArgs args)
        {
            return View(GetCalculateViewModel(args));
        }

        [HttpPost]
        public ActionResult Export(ViewModels.Home.CalculateArgs args)
        {
            var vm = GetCalculateViewModel(args);
            var path = HttpContext.Server.MapPath("~/App_Data/estimate.xlsx");

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(path)))
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                int row = 1;
                ExcelWorksheet assumptions = package.Workbook.Worksheets.Add("Assumptions");
                assumptions.Cells[row++, 1].Value = $"Starting TB";
                assumptions.Cells[row++, 1].Value = $"New TBs (per month)";
                assumptions.Cells[row++, 1].Value = $"% of stored Retrieval Monthly";
                assumptions.Cells[row++, 1].Value = $"# of main transactions per month (per 10,000)";
                assumptions.Cells[row++, 1].Value = $"# of other transactions per month (per 10,000)";
                assumptions.Cells[row++, 1].Value = $"# of months to project";

                row = 1;
                assumptions.Cells[row++, 2].Value = args.StartingStorage;
                assumptions.Cells[row++, 2].Value = args.MonthlyGrowthStorage;
                assumptions.Cells[row++, 2].Value = args.PctStorageRetrieval;
                assumptions.Cells[row++, 2].Value = args.MainTransactions;
                assumptions.Cells[row++, 2].Value = args.OtherTransactions;
                assumptions.Cells[row++, 2].Value = args.MonthsToProject;

                assumptions.Cells[1, 1, row - 1, 2].AutoFitColumns();

                ExcelHelper.RenderDetail(package, "Summary", vm.Summary);
                ExcelHelper.RenderDetail(package, "LRS Cool", vm.LocallyRedundantCool);
                ExcelHelper.RenderDetail(package, "LRS Hot", vm.LocallyRedundantHot);
                ExcelHelper.RenderDetail(package, "GRS Cool", vm.GeographicallyRedundantCool);
                ExcelHelper.RenderDetail(package, "GRS Hot", vm.GeographicallyRedundantHot);
                ExcelHelper.RenderDetail(package, "RA-GRS Cool", vm.ReadAccessGeographicallyRedundantCool);
                ExcelHelper.RenderDetail(package, "RA-GRS Hot", vm.ReadAccessGeographicallyRedundantHot);

                package.SaveAs(ms);
                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "estimate.xlsx");
            }
        }

        private ViewModels.Home.CalculateResult GetCalculateViewModel(ViewModels.Home.CalculateArgs args)
        {
            var vm = new ViewModels.Home.CalculateResult();
            vm.Args = args;
            vm.LocallyRedundantCool = Calculate(StorageRedundancy.LocallyRedundant, StorageTemperature.Cool, args);
            vm.LocallyRedundantHot = Calculate(StorageRedundancy.LocallyRedundant, StorageTemperature.Hot, args);
            vm.GeographicallyRedundantCool = Calculate(StorageRedundancy.GeographicallyRedundant, StorageTemperature.Cool, args);
            vm.GeographicallyRedundantHot = Calculate(StorageRedundancy.GeographicallyRedundant, StorageTemperature.Hot, args);
            vm.ReadAccessGeographicallyRedundantCool = Calculate(StorageRedundancy.ReadAccessGeographicallyRedundant, StorageTemperature.Cool, args);
            vm.ReadAccessGeographicallyRedundantHot = Calculate(StorageRedundancy.ReadAccessGeographicallyRedundant, StorageTemperature.Hot, args);

            vm.Summary = new List<ViewModels.Home.CalculateResultSummary>();
            vm.Summary.Add(Calculate(StorageRedundancy.LocallyRedundant, StorageTemperature.Cool, vm.LocallyRedundantCool));
            vm.Summary.Add(Calculate(StorageRedundancy.LocallyRedundant, StorageTemperature.Hot, vm.LocallyRedundantHot));
            vm.Summary.Add(Calculate(StorageRedundancy.GeographicallyRedundant, StorageTemperature.Cool, vm.GeographicallyRedundantCool));
            vm.Summary.Add(Calculate(StorageRedundancy.GeographicallyRedundant, StorageTemperature.Hot, vm.GeographicallyRedundantHot));
            vm.Summary.Add(Calculate(StorageRedundancy.ReadAccessGeographicallyRedundant, StorageTemperature.Cool, vm.ReadAccessGeographicallyRedundantCool));
            vm.Summary.Add(Calculate(StorageRedundancy.ReadAccessGeographicallyRedundant, StorageTemperature.Hot, vm.ReadAccessGeographicallyRedundantHot));
            return vm;
        }


        private ViewModels.Home.CalculateResultSummary Calculate(StorageRedundancy redundancy, StorageTemperature temperature, List<ViewModels.Home.CalculateResultDetail> details)
        {
            var tmp = new ViewModels.Home.CalculateResultSummary();

            tmp.StorageRedundancy = redundancy;
            tmp.StorageTemperature = temperature;
            tmp.TotalGB = details.Sum(x => x.GbStored);
            tmp.TotalPrice = details.Sum(x => x.TotalPrice);
            tmp.AveragePricePerGB = tmp.TotalPrice / tmp.TotalGB;
            tmp.AveragePricePerTB = tmp.AveragePricePerGB * 1000;
            return tmp;
        }

        private List<ViewModels.Home.CalculateResultDetail> Calculate(StorageRedundancy redundancy, StorageTemperature temperature, ViewModels.Home.CalculateArgs args)
        {
            var results = new List<ViewModels.Home.CalculateResultDetail>();
            var atRestPrices = AtRestPrice.GetDefault();
            var otherPrices = OtherPrice.GetDefault();
            var mainTransactionRate = otherPrices.FirstOrDefault(x => x.StorageRedundancy == redundancy
                                                                   && x.StorageTemperature == temperature
                                                                   && x.PriceType == OtherPriceType.BlobBlockPutListCreateContainer);
            var otherTransactionRate = otherPrices.FirstOrDefault(x => x.StorageRedundancy == redundancy
                                                                   && x.StorageTemperature == temperature
                                                                   && x.PriceType == OtherPriceType.BlobBlockOther);
            var retreivedRate = otherPrices.FirstOrDefault(x => x.StorageRedundancy == redundancy
                                                                   && x.StorageTemperature == temperature
                                                                   && x.PriceType == OtherPriceType.DataRetrieval);
            var writeRate = otherPrices.FirstOrDefault(x => x.StorageRedundancy == redundancy
                                                                   && x.StorageTemperature == temperature
                                                                   && x.PriceType == OtherPriceType.DataWrite);
            var replicationRate = otherPrices.FirstOrDefault(x => x.StorageRedundancy == redundancy
                                                                   && x.StorageTemperature == temperature
                                                                   && x.PriceType == OtherPriceType.GeoReplication);
            
            for (int i = 0; i <= args.MonthsToProject; i++)
            {
                results.Add(Calculate(redundancy, temperature, args, i, atRestPrices, mainTransactionRate, otherTransactionRate, retreivedRate, writeRate, replicationRate));
            }

            return results;
        }

        private ViewModels.Home.CalculateResultDetail Calculate(StorageRedundancy redundancy, StorageTemperature temperature, ViewModels.Home.CalculateArgs args, int month, 
            List<AtRestPrice> atRestPrices, OtherPrice mainTransactionRate, OtherPrice otherTransactionRate, OtherPrice retreivedRate, OtherPrice writeRate, OtherPrice replicationRate)
        {
            var tmp = new ViewModels.Home.CalculateResultDetail();
            tmp.Month = month;
            tmp.GbStored = (args.StartingStorage * 1000) + (month * args.MonthlyGrowthStorage * 1000);

            if (month == 0)
                tmp.GbWritten = (args.StartingStorage * 1000);
            else
                tmp.GbWritten = (args.MonthlyGrowthStorage * 1000);

            tmp.GbRetreived = tmp.GbStored * args.PctStorageRetrieval;

            var price = atRestPrices.Where(x => x.StorageRedundancy == redundancy
                                                       && x.StorageTemperature == temperature
                                                       && x.SizeCutoff > tmp.GbStored)
                                    .OrderByDescending(x => x.Amount)
                                    .FirstOrDefault();
            
            //This allows for sizing storage over 4 PBs
            if (price == null)
            {
                price = atRestPrices.Where(x => x.StorageRedundancy == redundancy
                                                       && x.StorageTemperature == temperature)
                                    .OrderBy(x => x.Amount)
                                    .FirstOrDefault();
            }

            tmp.PricePerGb = price.Amount;
            tmp.StoredPrice = tmp.GbStored * tmp.PricePerGb;
            tmp.MainTransPrice = args.MainTransactions * mainTransactionRate.Amount;
            tmp.OtherTransPrice = args.OtherTransactions * otherTransactionRate.Amount;
            tmp.PriceRetreived = tmp.GbRetreived * retreivedRate.Amount;
            tmp.PriceWrites = tmp.GbWritten * writeRate.Amount;
            tmp.PriceReplication = tmp.GbWritten * replicationRate.Amount;
            tmp.TotalPrice = tmp.StoredPrice + tmp.MainTransPrice + tmp.OtherTransPrice + tmp.PriceRetreived + tmp.PriceWrites + tmp.PriceReplication;

            return tmp;
        }
    }
}