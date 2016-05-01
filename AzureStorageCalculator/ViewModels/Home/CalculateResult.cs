using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureStorageCalculator.ViewModels.Home
{
    public class CalculateResult
    {
        public CalculateArgs Args { get; set; }
        public List<CalculateResultDetail> ReadAccessGeographicallyRedundantHot { get; set; }
        public List<CalculateResultDetail> ReadAccessGeographicallyRedundantCool { get; set; }
        public List<CalculateResultDetail> GeographicallyRedundantHot { get; set; }
        public List<CalculateResultDetail> GeographicallyRedundantCool { get; set; }
        public List<CalculateResultDetail> LocallyRedundantHot { get; set; }
        public List<CalculateResultDetail> LocallyRedundantCool { get; set; }
        public List<CalculateResultSummary> Summary { get; set; }
    }
}