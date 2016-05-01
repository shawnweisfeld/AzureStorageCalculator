using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.Models
{
    public class AtRestPrice
    {
        /// <summary>
        /// LRS, GRS, RA-GRS
        /// </summary>
        public StorageRedundancy StorageRedundancy { get; set; }
        /// <summary>
        /// Cool, Hot
        /// </summary>
        public StorageTemperature StorageTemperature { get; set; }
        /// <summary>
        /// Size Cutoff (in GB)
        /// </summary>
        public int SizeCutoff { get; set; }
        /// <summary>
        /// How much per GB per month
        /// </summary>
        public double Amount { get; set; }
    }
}