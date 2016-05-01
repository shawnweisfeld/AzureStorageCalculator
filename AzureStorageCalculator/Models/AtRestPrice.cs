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

        public static List<AtRestPrice> GetDefault()
        {
            return new List<AtRestPrice>()
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
        }
    }
}