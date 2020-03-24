using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
	public interface IUserService
	{
		Task<UserModel> CreateAsync(CreateUserRequest request, CancellationToken token);

		Task<UserModel> GetAsync(string userId, CancellationToken token);
        Task<List<UserModel>> GetListAsync(CancellationToken token);
        Task<UserModel> UpdateAsync(UpdateUserRequest request , CancellationToken token);

        Task<string> DeleteAsync(string userId, CancellationToken token);
    }
}