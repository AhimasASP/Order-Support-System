using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OSS.Domain.Interfaces.Services
{
    public interface IService<TModel, in TCreateRequest, in TUpdateRequest>
    {
        Task<TModel> CreateAsync(TCreateRequest request, CancellationToken token);

        Task<TModel> GetAsync(Guid id, CancellationToken token);

        Task<List<TModel>> GetListAsync(CancellationToken token);

        Task<List<TModel>> GetFilteredAsync(string param, CancellationToken token);

        Task<TModel> UpdateAsync(Guid id, TUpdateRequest request, CancellationToken token);

        Task<string> DeleteAsync(Guid id, CancellationToken token);
    }
}