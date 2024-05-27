using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Application.Common.Models.Setups
{
    public class SetupResponse
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Factors { get; set; }
    }
}

