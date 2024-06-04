using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Common.Models.Analysis
{
    public class SetupsEfficiencyResponse
    {
        public List<SetupsEfficiency> Setups { get; set; }
    }
    public class SetupsEfficiency
    {
        public string SetupId { get; set; }
        public double Efficiency { get; set; }
    }
}
