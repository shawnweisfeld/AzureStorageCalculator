using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.Models
{
    public enum StorageRedundancy
    {
        LocallyRedundant,
        GeographicallyRedundant,
        ReadAccessGeographicallyRedundant,    }
}