using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Identity;
using OSS.Domain.Common.Models.Api.Requests;

namespace OSS.Domain.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<string> LogInAsync(LoginRequest request);

        Task<string> LogOutAsync();
    }
}