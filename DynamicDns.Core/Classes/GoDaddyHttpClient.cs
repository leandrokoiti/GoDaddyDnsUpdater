using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DynamicDns.Core.Dto;
using Newtonsoft.Json;
using DynamicDns.Core.Interfaces;

namespace DynamicDns.Core.Classes
{
    /// <summary>
    /// <see cref="System.Net.Http.HttpClient"/> wrapper that includes the Authorization header on each request.
    /// </summary>
    public class GoDaddyHttpClient : HttpClient, IDnsClient
    {
        #region Constructors
        public GoDaddyHttpClient(string apiKey, string apiSecret)
        {
            this.DefaultRequestHeaders.Add("Authorization", $"sso-key {apiKey}:{apiSecret}");
        }
        #endregion

        #region Methods
        public async Task<List<DomainSummaryDto>> ListDomains()
        {
            var resultString = await this.GetStringAsync($"https://api.godaddy.com/v1/domains?statuses=ACTIVE");
            return JsonConvert.DeserializeObject<List<DomainSummaryDto>>(resultString);
        }

        public async Task<List<RecordDto>> GetARecord(DomainSummaryDto domain)
        {
            var resultString = await this.GetStringAsync($"https://api.godaddy.com/v1/domains/{domain.Domain}/records/A");
            return JsonConvert.DeserializeObject<List<RecordDto>>(resultString);
        }

        public async Task UpdateARecord(DomainSummaryDto domain, RecordDto record, int ttl, string ip)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new[]
            {
                new {
                    ttl = ttl,
                    data = ip
                }
            }), Encoding.UTF8, "application/json");

            var response = await this.PutAsync($"https://api.godaddy.com/v1/domains/{domain.Domain}/records/A/{record.Name}", content);
            response.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
