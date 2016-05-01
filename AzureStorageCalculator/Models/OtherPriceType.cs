using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.Models
{
    public enum OtherPriceType
    {
        [Description("Put Blob/Block, List, Create Container Operations (per 10,000)")]
        BlobBlockPutListCreateContainer,

        [Description("All other operations except Delete, which is free (per 10,000)")]
        BlobBlockOther,
        
        [Description("Data Retrieval (per GB)")]
        DataRetrieval,

        [Description("Data Write (per GB)")]
        DataWrite,

        [Description("Geo-Replication Data Transfer (per GB)")]
        GeoReplication,

    }
}