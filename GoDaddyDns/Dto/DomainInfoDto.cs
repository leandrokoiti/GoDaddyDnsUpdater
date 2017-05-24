using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns.Dto
{
    public class AddressMailing
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class ContactRegistrant
    {
        public string nameFirst { get; set; }
        public string nameMiddle { get; set; }
        public string nameLast { get; set; }
        public string organization { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public AddressMailing addressMailing { get; set; }
    }

    public class AddressMailing2
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class ContactBilling
    {
        public string nameFirst { get; set; }
        public string nameMiddle { get; set; }
        public string nameLast { get; set; }
        public string organization { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public AddressMailing2 addressMailing { get; set; }
    }

    public class AddressMailing3
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class ContactAdmin
    {
        public string nameFirst { get; set; }
        public string nameMiddle { get; set; }
        public string nameLast { get; set; }
        public string organization { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public AddressMailing3 addressMailing { get; set; }
    }

    public class AddressMailing4
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class ContactTech
    {
        public string nameFirst { get; set; }
        public string nameMiddle { get; set; }
        public string nameLast { get; set; }
        public string organization { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public AddressMailing4 addressMailing { get; set; }
    }

    public class Record
    {
        public string type { get; set; }
        public string name { get; set; }
        public string data { get; set; }
        public int priority { get; set; }
        public int ttl { get; set; }
        public string service { get; set; }
        public string protocol { get; set; }
        public int port { get; set; }
        public int weight { get; set; }
    }

    public class DomainSummaryDto
    {
        public double domainId { get; set; }
        public string domain { get; set; }
        public string status { get; set; }
        public string expires { get; set; }
        public bool expirationProtected { get; set; }
        public bool holdRegistrar { get; set; }
        public bool locked { get; set; }
        public bool privacy { get; set; }
        public bool renewAuto { get; set; }
        public bool renewable { get; set; }
        public string renewDeadline { get; set; }
        public bool transferProtected { get; set; }
        public string createdAt { get; set; }
        public string deletedAt { get; set; }
        public string authCode { get; set; }
        public List<string> nameServers { get; set; }
        public ContactRegistrant contactRegistrant { get; set; }
        public ContactBilling contactBilling { get; set; }
        public ContactAdmin contactAdmin { get; set; }
        public ContactTech contactTech { get; set; }
        public List<Record> records { get; set; }
    }
}
