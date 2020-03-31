using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
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
            var model = new UserDbModel
            {
                Login = request.Login,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Photo = request.Photo,
                Role = request.Role,
                CreationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            await _repository.CreateAsync(model, token);
            return model.ConvertTo<UserModel>();
        }

        public async Task<UserModel> GetAsync(Guid id, CancellationToken token)
        {
            return (await _repository.GetAsync(id, token)).ConvertTo<UserModel>();
        }

        public async Task<List<UserModel>> GetListAsync(CancellationToken token)
        {
            return (await _repository.GetListAsync(token)).ConvertTo<List<UserModel>>();
        }

        public Task<List<UserModel>> GetFilteredAsync(string type, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken token)
        {
            var model = await _repository.GetAsync(id, token);
            model.Login = request.Login;
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.Photo = request.Photo;
            model.Role = request.Role;
            model.ModificationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await _repository.UpdateAsync(model, token);

            return model.ConvertTo<UserModel>();
        }

        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _repository.DeleteAsync(id, token);
        }
    }
}