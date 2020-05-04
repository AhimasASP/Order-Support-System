using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Data.Interfaces;

namespace OSS.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetListAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public Task<List<IdentityRole>> GetFilteredAsync(Expression<Func<IdentityRole, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(IdentityRole model)
        {
            var result = await _roleManager.CreateAsync(model);
            return result.Succeeded;
        }

        public async Task<bool> UpdateAsync(IdentityRole model)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
            return result.Succeeded;
                
        }
    }
}