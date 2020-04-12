using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<string> LogInAsync(LoginRequest request)
        {
            return await _authorizationService.LogInAsync(request);
        }

        [HttpPost]
        public async Task<string> LogOutAsync()
        {
            return await _authorizationService.LogOutAsync();
        }

    }
}
