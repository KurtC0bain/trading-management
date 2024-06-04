using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Common.Models.Analysis
{
    public class AssetsIncomeResponse
    {
        public List<AssetIncome> Assets { get; set; }
    }

    public class AssetIncome
    {
        public string AssetId { get; set; }
        public double Income { get; set; }
    }
}
