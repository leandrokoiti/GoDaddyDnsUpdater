using DynamicDns.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDns.Core.Interfaces
{
    public interface IIpRetriever
    {
        Task<IpInfoDto> GetCurrentIp();
    }
}
