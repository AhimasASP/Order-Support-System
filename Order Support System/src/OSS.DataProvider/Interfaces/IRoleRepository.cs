using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole>> GetListAsync();
        Task<IdentityRole> GetAsync(string id);
        Task<List<IdentityRole>> GetFilteredAsync(Expression<Func<IdentityRole, bool>> expression);
        Task<bool> CreateAsync(IdentityRole model);
        Task<bool> UpdateAsync(IdentityRole model);
        Task<bool> DeleteAsync(string id);
    }
}