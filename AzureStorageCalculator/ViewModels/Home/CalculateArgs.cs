using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateArgs
    {
        public double StartingStorage { get; set; }
        public double MonthlyGrowthStorage { get; set; }
        public double PctStorageRetrieval { get; set; }
        public int MainTransactions { get; set; }
        public int OtherTransactions { get; set; }
        public int MonthsToProject { get; set; }
    }
}