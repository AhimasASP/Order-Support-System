using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Common.Constants;
using OSS.Data.Interfaces;
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
            List<UserDbModel> users = new List<UserDbModel>();
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (user.IsDeleted != true)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        public async Task<UserDbModel> GetAsync(string id)
        {
           UserDbModel user = await _userManager.FindByIdAsync(id);
           if (user.IsDeleted != true)
           {
               return user;
           }
           else
           {
               return null;
           }
        }

        public Task<List<UserDbModel>> GetFilteredAsync(Expression<Func<UserDbModel, bool>> expression)
        {
            return _userManager.Users.Where(expression).ToListAsync();
        }

        public async Task<string> CreateAsync(UserDbModel model)
        {
            if (model.PasswordHash == null)
            {
                model.PasswordHash = ConstantsValue.DefaultPassword;
            }
            var result = await _userManager.CreateAsync(model, model.PasswordHash);
          
            return model.Id;
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

        public async Task<bool> AddUserToRoleAsync(string name, string role)
        {
            UserDbModel user = await _userManager.FindByNameAsync(name);
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string id, string role)
        {
            UserDbModel user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }
    }
}