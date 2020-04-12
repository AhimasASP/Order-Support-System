using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using OSS.WebApplication.Configurations.Entity;
using ServiceStack;

namespace OSS.Domain.Logic.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<UserDbModel> _manager;

        public UserService(UserManager<UserDbModel> manager)
        {
            _manager = manager;
        }

        public async Task<UserModel> CreateAsync(CreateUserRequest request, CancellationToken token)
        {
            UserDbModel user = new UserDbModel
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.Phone,
                Email = request.Email,
                Photo = request.Photo,
                CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var result = await _manager.CreateAsync(user, request.Password);
            if ((await (_manager.AddToRoleAsync(user, "user"))).Succeeded)
            {
                user.Photo = "role added!";
            }

            if (result.Succeeded)
            {
                return user.ConvertTo<UserModel>();
            }

            return user.ConvertTo<UserModel>();

        }

        public async Task<UserModel> GetAsync(Guid id, CancellationToken token)
        {
            return (await _manager.FindByIdAsync(id.ToString())).ConvertTo<UserModel>();
        }

        public async Task<List<UserModel>> GetListAsync(CancellationToken token)
        {
            return (await _manager.Users.ToListAsync(token)).ConvertTo<List<UserModel>>();
        }

        public Task<List<UserModel>> GetFilteredAsync(string type, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        public async Task<UserModel> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken token)
        {
            var user = await _manager.FindByIdAsync(id.ToString());
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.Phone;
            user.Email = request.Email;
            user.Photo = request.Photo;
            user.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await _manager.UpdateAsync(user);

            return user.ConvertTo<UserModel>();
        }
        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _manager.DeleteAsync(await _manager.FindByIdAsync(id.ToString()));
            if (result.Succeeded)
            {
                return "Ok!";
            }

            return "Fail";
        }
    }
}