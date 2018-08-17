using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicDns.Core.Dto;

namespace DynamicDns.Core.Interfaces
{
    public interface IDnsClient
    {
        Task<List<RecordDto>> GetARecord(DomainSummaryDto domain);
        Task<List<DomainSummaryDto>> ListDomains();
        Task UpdateARecord(DomainSummaryDto domain, RecordDto record, int ttl, string ip);
    }
}