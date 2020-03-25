using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Models.ApiModels;

namespace OSS.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<List<TModel>> GetListAsync(CancellationToken token);
        Task<TModel> GetAsync(Guid id, CancellationToken token);
        Task<string> CreateAsync(TModel model, CancellationToken token);
        Task<string> UpdateAsync(TModel model, CancellationToken token);
        Task<string> DeleteAsync(TModel model, CancellationToken token);

    }
}