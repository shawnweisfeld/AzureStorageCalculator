using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateResultDetail
    {
        public int Month { get; set; }
        public double GbStored { get; set; }
        public double GbWritten { get; set; }
        public double GbRetreived { get; set; }
        public double PricePerGb { get; set; }
        public double StoredPrice { get; set; }
        public double MainTransPrice { get; set; }
        public double OtherTransPrice { get; set; }
        public double PriceRetreived { get; set; }
        public double PriceWrites { get; set; }
        public double PriceReplication { get; set; }
        public double TotalPrice { get; set; }
    }
}