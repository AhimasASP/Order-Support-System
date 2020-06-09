using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;

namespace OSS.Domain.Logic.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly SignInManager<UserDbModel> _signInManager;
        private readonly UserManager<UserDbModel> _userManager;

        public AuthorizationService(SignInManager<UserDbModel> manager, UserManager<UserDbModel> userManager)
        {
            _signInManager = manager;
            _userManager = userManager;
        }

        public async Task<string> LogInAsync(LoginRequest request)
        {
            UserDbModel user = await _userManager.FindByNameAsync(request.UserName);
      

            if (user != null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

                if (result.Succeeded)
                {
                      await _signInManager.SignInAsync(user, false);

                    return "ok";
                }
            }

            return "Fail";
        }


        public async Task<string> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return "Ok!";
        }
    }
}