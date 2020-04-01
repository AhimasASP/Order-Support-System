using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Interfaces.Services
{
	public interface IUserService
	{
        Task<UserModel> CreateAsync(CreateUserRequest request, CancellationToken token);

        Task<UserModel> GetAsync(Guid id, CancellationToken token);

        Task<List<UserModel>> GetListAsync(CancellationToken token);

        Task<List<UserModel>> GetFilteredAsync(string type, CancellationToken token);

        Task<UserModel> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken token);

        Task<string> DeleteAsync(Guid id, CancellationToken token);
    }
}