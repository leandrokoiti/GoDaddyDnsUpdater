using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicDns.Core.Dto;

namespace DynamicDns.Core.Interfaces
{
    public interface IDnsManager
    {
        Task<List<DomainSummaryDto>> ListDomains();
        Task UpdateAllDomains(string newIp);
        Task UpdateDomain(DomainSummaryDto domain, string newIp);
        Task UpdateRecord(DomainSummaryDto domain, RecordDto record, string newIp);
    }
}