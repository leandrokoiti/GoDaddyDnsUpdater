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
    /// <summary>
    /// <see cref="HttpClient"/> wrapper that includes the Authorization header on each request.
    /// </summary>
    public class GoDaddyHttpClient : HttpClient
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
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                ttl = ttl,
                data = ip
            }), Encoding.UTF8, "application/json");

            await this.PutAsync($"https://api.godaddy.com/v1/domains/{domain.Domain}/records/A/{record.Name}", content);
        } 
        #endregion
    }
}
