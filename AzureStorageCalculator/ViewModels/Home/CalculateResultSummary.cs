using AzureStorageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateResultSummary
    {
        public StorageRedundancy StorageRedundancy { get; set; }
        public StorageTemperature StorageTemperature { get; set; }
        public double TotalGB { get; set; }
        public double TotalPrice { get; set; }
        public double AveragePricePerGB { get; set; }
        public double AveragePricePerTB { get; set; }

    }
}