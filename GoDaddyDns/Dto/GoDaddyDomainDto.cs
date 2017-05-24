using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns.Dto
{
    public class GoDaddyDomainDto
    {
        public string Name { get; set; }
        public string A { get; set; }
        public DateTime? LastUpdated { get; set; }
        public UpdateStatus? Status { get; set; }
    }
}
