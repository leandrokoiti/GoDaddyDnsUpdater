using EncryptStringSample;
using GoDaddyDns.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns
{
    public class DnsManager
    {
        public string ApiKey
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.gdApiKey))
                    return StringCipher.Decrypt(Properties.Settings.Default.gdApiKey, Program.Password);
                else
                    return string.Empty;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    Properties.Settings.Default.gdApiKey = StringCipher.Encrypt(value, Program.Password);
                else
                    Properties.Settings.Default.gdApiKey = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        public string ApiSecret
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.gdApiSecret))
                    return StringCipher.Decrypt(Properties.Settings.Default.gdApiSecret, Program.Password);
                else
                    return string.Empty;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    var oldApiSecret = Properties.Settings.Default.gdApiSecret;
                    if (String.IsNullOrWhiteSpace(value) && !String.IsNullOrWhiteSpace(oldApiSecret))
                        value = StringCipher.Decrypt(oldApiSecret, Program.Password);

                    Properties.Settings.Default.gdApiSecret = StringCipher.Encrypt(value, Program.Password);
                }
                else
                {
                    Properties.Settings.Default.gdApiSecret = string.Empty;
                }

                Properties.Settings.Default.Save();
            }
        }

        #region Storage Specific Methods
        /// <summary>
        /// Returns a list of all domains stored within this application.
        /// </summary>
        /// <returns>Returns a <see cref="IEnumerable<GoDaddyDomainDto>"/> containing all domains stored within this application.</returns>
        public async Task<List<DomainSummaryDto>> ListDomains()
        {
            using (var client = new HttpClient())
            {
                setApiAuthorization(client);

                var resultString = await client.GetStringAsync($"https://api.godaddy.com/v1/domains?statuses=ACTIVE");

                var domains = JsonConvert.DeserializeObject<List<DomainSummaryDto>>(resultString);
                foreach (var d in domains)
                {
                    resultString = await client.GetStringAsync($"https://api.godaddy.com/v1/domains/{d.domain}/records/A");
                    d.records = JsonConvert.DeserializeObject<List<Record>>(resultString);
                }
                return domains;
            }

            //var domains = JsonConvert.DeserializeObject<List<GoDaddyDomainDto>>(Properties.Settings.Default.appDomains);
            //if (domains == null)
            //{
            //    domains = new List<GoDaddyDomainDto>();
            //    Properties.Settings.Default.appDomains = JsonConvert.SerializeObject(domains);
            //    Properties.Settings.Default.Save();
            //}
            //return domains;
        }

        /// <summary>
        /// Adds or replaces an existing domain with the domain information passed.
        /// </summary>
        /// <param name="domainName">The name of the domain to be saved.</param>
        /// <param name="aName">The "A" name of the domain to be saved.</param>
        /// <returns>Returns the domain stored within the application.</returns>
        /// <remarks>A domain is considered equal if both its <paramref name="domainName"/> and <paramref name="aName"/> are equal any of the of the domain stored within the application.</remarks>
        public GoDaddyDomainDto AddDomain(string domainName, string aName)
        {
            return null;
            //var domain = GetDomain(domainName, aName);

            //if (domain == null)
            //    domain = new GoDaddyDomainDto()
            //    {
            //        LastUpdated = null,
            //        Status = UpdateStatus.NA
            //    };

            //domain.A = aName;
            //domain.Name = domainName;

            //SaveDomain(domain);

            //return domain;
        }

        /// <summary>
        /// Adds or replaces an existing domain with the domain information passed.
        /// </summary>
        /// <param name="domainToSave">The domain to be saved.</param>
        /// <remarks>A domain is considered equal if both its <paramref name="domainName"/> and <paramref name="aName"/> are equal any of the of the domain stored within the application.</remarks>
        public void SaveDomain(GoDaddyDomainDto domainToSave)
        {
            //var domains = await ListDomains();
            //var domain = domains.Where(d => findDomain(domainToSave.Name, domainToSave.A, d)).FirstOrDefault();
            //if (domain == null)
            //{
            //    domain = new DomainSummaryDto();
            //}
            //else
            //{
            //    domain.A = domainToSave.A;
            //    domain.LastUpdated = domainToSave.LastUpdated;
            //    domain.Name = domainToSave.Name;
            //    domain.Status = domainToSave.Status;
            //}

            //Properties.Settings.Default.appDomains = JsonConvert.SerializeObject(domains);
            //Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Returns the domain if found within this application, null otherwise.
        /// </summary>
        /// <param name="domainName">The name of the domain to look for.</param>
        /// <param name="aName">The "A" name of the domain to look for.</param>
        /// <returns>Returns <see cref="DomainSummaryDto"/> with the information of the requested domain, or null if the domain can't be found.</returns>
        private async Task<DomainSummaryDto> GetDomain(string domainName, string aName)
        {
            return (await ListDomains()).Where(d => findDomain(domainName, aName, d)).FirstOrDefault();
        }

        /// <summary>
        /// Removes a collection of domains from the list of domains stored within this application.
        /// </summary>
        /// <param name="domainsToRemove"></param>
        /// <returns></returns>
        public void RemoveDomains(IEnumerable<GoDaddyDomainDto> domainsToRemove)
        {
            //foreach (var d in domainsToRemove)
            //{
            //    RemoveDomain(d);
            //}
        }

        /// <summary>
        /// Removes the given domain from the list of domains stored within this application.
        /// </summary>
        /// <param name="domainToRemove"></param>
        private void RemoveDomain(GoDaddyDomainDto domainToRemove)
        {
            //var domains = await ListDomains();

            //if (domains != null)
            //{
            //    var domain = domains.Where(d => findDomain(domainToRemove.Name, domainToRemove.A, d)).FirstOrDefault();
            //    if (domain != null)
            //    {
            //        domains.Remove(domain);

            //        Properties.Settings.Default.appDomains = JsonConvert.SerializeObject(domains);
            //        Properties.Settings.Default.Save();
            //    }
            //}
        }
        #endregion

        #region Network Related Methods
        /// <summary>
        /// Updates all domains stored within this application with the new ip information.
        /// </summary>
        /// <param name="newIp">The new ip to update the domains with.</param>
        /// <remarks>This method send a post to the Go Daddy API to update the domains.</remarks>
        public async Task UpdateAllDomains(string newIp)
        {
            var domains = await ListDomains();

            foreach (var d in domains)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        setApiAuthorization(client);

                        var resultString = await client.GetStringAsync($"https://api.godaddy.com/v1/domains/{d.domain}/records/A");
                        var records = JsonConvert.DeserializeObject<Record[]>(resultString);
                        if (records != null)
                        {
                            foreach (var record in records)
                            {
                                var currentIp = record.data;

                                if (currentIp != newIp)
                                {
                                    await UpdateRecord(d, record, newIp);
                                    //d.LastUpdated = DateTime.Now;
                                    //d.Status = UpdateStatus.OK;
                                }
                                else
                                {
                                    //d.Status = UpdateStatus.NotChanged;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    //d.Status = UpdateStatus.Error;
                }

                //SaveDomain(d);
            }
        }

        /// <summary>
        /// Updates the specified domain with its new ip information.
        /// </summary>
        /// <param name="domain">The domain to be updated.</param>
        /// <param name="newIp">The new IP that will be set to it.</param>
        /// <returns></returns>
        public async Task UpdateRecord(DomainSummaryDto domain, Record record, string newIp)
        {
            using (var client = new HttpClient())
            {
                setApiAuthorization(client);

                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    ttl = record.ttl,
                    data = newIp
                }), Encoding.UTF8, "application/json");

                await client.PutAsync($"https://api.godaddy.com/v1/domains/{domain.domain}/records/A/{record.name}", content);
            }
        }

        /// <summary>
        /// Returns the current ip information for the requesting machine.
        /// </summary>
        /// <returns>Returns <see cref="IpInfoDto"/> containing all the information sent by the server.</returns>
        public async Task<IpInfoDto> GetCurrentIp()
        {
            using (var client = new HttpClient())
            {
                var ipInfoString = await client.GetStringAsync(new Uri("http://ipinfo.io/json"));
                var ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfoDto>(ipInfoString);
                return ipInfo;
            }
        }
        #endregion

        #region Support Methods
        private static bool findDomain(string domainName, string aName, DomainSummaryDto d)
        {
            return d.domain.ToLower() == domainName.ToLower() && d.records.Any(r=> aName.ToLower() == r.name.ToLower());
        }

        /// <summary>
        /// Sets the authorization header required to make requests to the GoDaddy API.
        /// </summary>
        /// <param name="client"></param>
        private void setApiAuthorization(HttpClient client)
        {
            if (client.DefaultRequestHeaders.Contains("Authorization"))
                client.DefaultRequestHeaders.Remove("Authorization");

            client.DefaultRequestHeaders.Add("Authorization", $"sso-key {this.ApiKey}:{this.ApiSecret}");
        }
        #endregion
    }
}
