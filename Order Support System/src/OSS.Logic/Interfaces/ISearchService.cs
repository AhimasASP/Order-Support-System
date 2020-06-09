using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface ISearchService
    {
        Task<List<BaseDbModel>> SearchAsync(string value, CancellationToken token);
    }
}