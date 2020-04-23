using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDbModel>> GetListAsync(CancellationToken token);
        Task<UserDbModel> GetAsync(Guid id, CancellationToken token);
        Task<List<UserDbModel>> GetFilteredAsync(Expression<Func<UserDbModel, bool>> expression, CancellationToken token);
        Task<string> CreateAsync(UserDbModel model, CancellationToken token);
        Task<string> UpdateAsync(UserDbModel model, CancellationToken token);
        Task<string> DeleteAsync(Guid id, CancellationToken token);

    }
}