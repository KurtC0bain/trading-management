using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Application.Common.Models.Setups
{
    public class SetupRequest
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Factors { get; set; }
    }
}
