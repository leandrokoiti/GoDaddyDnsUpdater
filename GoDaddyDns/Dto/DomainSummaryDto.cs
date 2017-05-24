using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns.Dto
{
    public class DomainSummaryDto
    {
        public double DomainId { get; set; }
        public string Domain { get; set; }
        public string Status { get; set; }
        public string Expires { get; set; }
        public bool ExpirationProtected { get; set; }
        public bool HoldRegistrar { get; set; }
        public bool Locked { get; set; }
        public bool Privacy { get; set; }
        public bool RenewAuto { get; set; }
        public bool Renewable { get; set; }
        public string RenewDeadline { get; set; }
        public bool TransferProtected { get; set; }
        public string CreatedAt { get; set; }
        public string DeletedAt { get; set; }
        public string AuthCode { get; set; }
        public List<string> NameServers { get; set; }
        public ContactDto ContactRegistrant { get; set; }
        public ContactDto ContactBilling { get; set; }
        public ContactDto ContactAdmin { get; set; }
        public ContactDto ContactTech { get; set; }
        public List<RecordDto> Records { get; set; }
    }
}
