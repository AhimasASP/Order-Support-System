using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : BaseDbModel
    {
        Task<List<TModel>> GetListAsync(CancellationToken token);
        Task<TModel> GetAsync(Guid id, CancellationToken token);
        Task<List<TModel>> GetFilteredAsync(Expression<Func<TModel, bool>> expression, CancellationToken token);
        Task<string> CreateAsync(TModel model, CancellationToken token);
        Task<string> UpdateAsync(TModel model, CancellationToken token);
        Task<string> DeleteAsync(Guid id, CancellationToken token);

    }
}