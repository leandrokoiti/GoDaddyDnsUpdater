using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DynamicDns.Core.Dto;

namespace DynamicDns.Core.Classes
{
    /// <summary>
    /// Class responsible for updating the IP of the domains registered with the credentials informed
    /// and load the external IP of the machine running the application.
    /// </summary>
    public class DnsManager
    {
        #region Constants
        protected const string IP_INFO_URL = "http://ipinfo.io/json";
        #endregion

        #region Fields
        private GoDaddyHttpClient _goDaddyClient;
        private int _defaultTtl;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the Dns Manager and stores the authentication information passed.
        /// </summary>
        /// <param name="apiKey"><see cref="GoDaddyDns.Program.ApiKey"/></param>
        /// <param name="apiSecret"><see cref="GoDaddyDns.Program.ApiSecret"/></param>
        public DnsManager(string apiKey, string apiSecret, int defaultTtl)
        {
            this._goDaddyClient = new GoDaddyHttpClient(apiKey, apiSecret);
            this._defaultTtl = defaultTtl;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves all domains available.
        /// </summary>
        /// <returns>Returns a <see cref="List<DomainSummaryDto>"/> containing all domains pertaining to the credentials informed.</returns>
        public async Task<List<DomainSummaryDto>> ListDomains()
        {
            var domains = await this._goDaddyClient.ListDomains();

            foreach (var d in domains)
                d.Records = await this._goDaddyClient.GetARecord(d);

            return domains;
        }

        /// <summary>
        /// Updates all domains of the credentials informed with the new ip information.
        /// </summary>
        /// <param name="newIp">The new ip to update the domains with.</param>
        public async Task UpdateAllDomains(string newIp)
        {
            var domains = await ListDomains();

            foreach (var d in domains)
                await UpdateDomain(d, newIp);
        }

        /// <summary>
        /// Updates the given domain with its new IP address.
        /// </summary>
        /// <param name="domain">The domain to be updated.</param>
        /// <param name="newIp">The new IP to update the domain with.</param>
        /// <returns></returns>
        public async Task UpdateDomain(DomainSummaryDto domain, string newIp)
        {
            var record = (await this._goDaddyClient.GetARecord(domain)).FirstOrDefault();

            var currentIp = record.Data;

            if (currentIp != newIp)
                await UpdateRecord(domain, record, newIp);
        }

        /// <summary>
        /// Updates the specified domain with its new ip information.
        /// </summary>
        /// <param name="domain">The domain to be updated.</param>
        /// <param name="newIp">The new IP that will be set to it.</param>
        /// <returns></returns>
        public async Task UpdateRecord(DomainSummaryDto domain, RecordDto record, string newIp)
        {
            await this._goDaddyClient.UpdateARecord(domain, record, this._defaultTtl, newIp);
        }

        /// <summary>
        /// Returns the current ip information for the requesting machine.
        /// </summary>
        /// <returns>Returns <see cref="IpInfoDto"/> containing all the information sent by the server.</returns>
        public async Task<IpInfoDto> GetCurrentIp()
        {
            using (var client = new HttpClient())
            {
                var ipInfoString = await client.GetStringAsync(new Uri(IP_INFO_URL));
                var ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfoDto>(ipInfoString);
                return ipInfo;
            }
        } 
        #endregion
    }
}
