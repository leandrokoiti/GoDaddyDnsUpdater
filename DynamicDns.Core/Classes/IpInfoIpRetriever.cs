using DynamicDns.Core.Dto;
using DynamicDns.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDns.Core.Classes
{
    public class IpInfoIpRetriever : IIpRetriever
    {
        #region Constants
        protected const string IP_INFO_URL = "http://ipinfo.io/json";
        #endregion

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
    }
}
