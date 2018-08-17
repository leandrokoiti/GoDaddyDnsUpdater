﻿using DynamicDns.Core.Dto;
using DynamicDns.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDns.Core.Classes
{
    /// <summary>
    /// Class responsible for updating the IP of the domains registered with the credentials informed
    /// and load the external IP of the machine running the application.
    /// </summary>
    public class DnsManager : IDnsManager
    {
        #region Fields
        private IDnsClient _dnsClient;
        private int _defaultTtl;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the Dns Manager and stores the authentication information passed.
        /// </summary>
        /// <param name="dnsClient">The DNS client to manage the requests</param>
        public DnsManager(IDnsClient dnsClient, int defaultTtl/* string apiKey, string apiSecret, int defaultTtl*/)
        {
            this._dnsClient = dnsClient;
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
            var domains = await this._dnsClient.ListDomains();

            foreach (var d in domains)
                d.Records = await this._dnsClient.GetARecord(d);

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
            var record = (await this._dnsClient.GetARecord(domain)).FirstOrDefault();

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
            await this._dnsClient.UpdateARecord(domain, record, this._defaultTtl, newIp);
        }
        #endregion
    }
}
