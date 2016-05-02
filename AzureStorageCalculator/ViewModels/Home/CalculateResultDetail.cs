using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateResultDetail
    {
        [Column(ColumnName = "Month", Ordinal = 1, Primary = true)]
        public int Month { get; set; }
        [Column(ColumnName = "GB Stored", Ordinal = 2)]
        public double GbStored { get; set; }
        [Column(ColumnName = "GB Written", Ordinal = 3)]
        public double GbWritten { get; set; }
        [Column(ColumnName = "GB Retreived", Ordinal = 4)]
        public double GbRetreived { get; set; }
        [Column(ColumnName = "Price Per GB", Ordinal = 5)]
        public double PricePerGb { get; set; }
        [Column(ColumnName = "Stored Price", Ordinal = 6)]
        public double StoredPrice { get; set; }
        [Column(ColumnName = "Main Trans Price", Ordinal = 7)]
        public double MainTransPrice { get; set; }
        [Column(ColumnName = "Other Trans Price", Ordinal = 8)]
        public double OtherTransPrice { get; set; }
        [Column(ColumnName = "Price Retreived", Ordinal = 9)]
        public double PriceRetreived { get; set; }
        [Column(ColumnName = "Price Writes", Ordinal = 10)]
        public double PriceWrites { get; set; }
        [Column(ColumnName = "Price Replication", Ordinal = 11)]
        public double PriceReplication { get; set; }
        [Column(ColumnName = "Total Price", Ordinal = 12)]
        public double TotalPrice { get; set; }
    }
}