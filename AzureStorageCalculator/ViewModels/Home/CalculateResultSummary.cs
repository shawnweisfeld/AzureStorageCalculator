using AzureStorageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateResultSummary
    {
        [Column(ColumnName = "Redundancy", Ordinal = 1, Primary = true)]
        public StorageRedundancy StorageRedundancy { get; set; }
        [Column(ColumnName = "Temperature", Ordinal = 2)]
        public StorageTemperature StorageTemperature { get; set; }
        [Column(ColumnName = "Total GB", Ordinal = 3)]
        public double TotalGB { get; set; }
        [Column(ColumnName = "Total Price", Ordinal = 4)]
        public double TotalPrice { get; set; }
        [Column(ColumnName = "Avg Price Per GB", Ordinal = 5)]
        public double AveragePricePerGB { get; set; }
        [Column(ColumnName = "Avg Price Per TB", Ordinal = 6)]
        public double AveragePricePerTB { get; set; }

    }
}