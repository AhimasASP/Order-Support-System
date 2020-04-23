using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDbModel>> GetListAsync();
        Task<UserDbModel> GetAsync(string id);
        Task<List<UserDbModel>> GetFilteredAsync(Expression<Func<UserDbModel, bool>> expression);
        Task<bool> CreateAsync(UserDbModel model);
        Task<bool> UpdateAsync(UserDbModel model);
        Task<bool> SoftDeleteAsync(string id);
    }
}