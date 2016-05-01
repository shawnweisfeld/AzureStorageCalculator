using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.Models
{
    public class OtherPrice
    {
        public OtherPriceType PriceType { get; set; }
        /// <summary>
        /// LRS, GRS, RA-GRS
        /// </summary>
        public StorageRedundancy StorageRedundancy { get; set; }
        /// <summary>
        /// Cool, Hot
        /// </summary>
        public StorageTemperature StorageTemperature { get; set; }
        /// <summary>
        /// How much per GB per month
        /// </summary>
        public double Amount { get; set; }

        public static List<OtherPrice> GetDefault()
        {
            return new List<OtherPrice>()
            {
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.1
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.05
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.20
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.10
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.20
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockPutListCreateContainer,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.10
                },

                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.004
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.004
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.BlobBlockOther,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.004
                },

                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.01
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataRetrieval,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },

                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.0025
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.005
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.005
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.DataWrite,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },

                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.LocallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.02
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.GeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.02
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Cool,
                    Amount = 0.02
                },
                new OtherPrice()
                {
                    PriceType = OtherPriceType.GeoReplication,
                    StorageRedundancy = StorageRedundancy.ReadAccessGeographicallyRedundant,
                    StorageTemperature = StorageTemperature.Hot,
                    Amount = 0.02
                },
            };
        }
    }
}