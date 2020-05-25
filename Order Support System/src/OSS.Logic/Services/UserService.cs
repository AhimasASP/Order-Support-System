using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Data.Interfaces;
using OSS.Data.Repositories;
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
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserModel> CreateAsync(CreateUserRequest request, CancellationToken token)
        {
            UserDbModel user = new UserDbModel
            {
                UserName = request.UserName,
                PasswordHash = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.Phone,
                Email = request.Email,
                Photo = request.Photo,
                CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var result = await _repository.CreateAsync(user);

            return user.ConvertTo<UserModel>();
        }

        public async Task<UserModel> GetAsync(Guid id, CancellationToken token)
        {
            return (await _repository.GetAsync(id.ToString())).ConvertTo<UserModel>();
        }

        public async Task<List<UserModel>> GetListAsync(CancellationToken token)
        {
            return (await _repository.GetListAsync()).ConvertTo<List<UserModel>>();
        }

        public Task<List<UserModel>> GetFilteredAsync(string type, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        public async Task<UserModel> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken token)
        {
            UserDbModel user = await _repository.GetAsync(id.ToString());

            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.Phone;
            user.Email = request.Email;
            user.Photo = request.Photo;
            user.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
           
            await _repository.UpdateAsync(user);

            return user.ConvertTo<UserModel>();
        }

        public Task<List<UserModel>> SearchAsync(string param, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _repository.SoftDeleteAsync(id.ToString());
            return result.ToString();
        }
    }
}