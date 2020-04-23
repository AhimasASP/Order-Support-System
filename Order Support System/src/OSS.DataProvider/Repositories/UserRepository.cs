using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<UserDbModel> _userManager;

        public UserRepository(UserManager<UserDbModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDbModel>> GetListAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<UserDbModel> GetAsync(string id)
        {
           return await _userManager.FindByIdAsync(id);
        }

        public Task<List<UserDbModel>> GetFilteredAsync(Expression<Func<UserDbModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(UserDbModel model)
        {
            var result = await _userManager.CreateAsync(model, model.PasswordHash);
          
            return result.Succeeded;
        }

        public async Task<bool> UpdateAsync(UserDbModel model)
        {
            var result = await _userManager.UpdateAsync(model);
            return result.Succeeded;
        }

        public async Task<bool> SoftDeleteAsync(string id)
        {
            UserDbModel model = await _userManager.FindByIdAsync(id);
            model.IsDeleted = true;
            var result = await _userManager.UpdateAsync(model);
            return result.Succeeded;
        }
    }
}