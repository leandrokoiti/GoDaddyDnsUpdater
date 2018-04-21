namespace DynamicDns.Core.Dto
{
    public class ContactDto
    {
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NameLast { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public AddressMailingDto AddressMailing { get; set; }
    }
}
