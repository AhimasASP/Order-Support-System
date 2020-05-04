using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface ISearchService
    {
        Task<List<SearchResponseModel>> SearchAsync(string value, CancellationToken token);
    }
}