using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace OSS.WebApplication.Controllers
{
    [Route("[Controller]/[action]")]
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [SwaggerResponse(200, "Show user details", typeof(string))]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken token)
        {
            return Ok(await _userService.GetAsync(id, token));
        }

        [HttpGet]
        [SwaggerResponse(200, "Show users list", typeof(string))]
        [SwaggerResponse(200, "Show user list")]
        public async Task<IActionResult> Index(CancellationToken token)
        {
            return Ok(await _userService.GetListAsync(token));
        }

        [HttpPost]
        [SwaggerResponse(201, "Add new user", typeof(string))]
        public async Task<IActionResult> CreateAsync([FromBody]CreateUserRequest request, CancellationToken cancellationToken)
        {
            var model = await _userService.CreateAsync(request, cancellationToken);

            if (model.IsValid)
            {
                return Ok(model);
            }

            return BadRequest(model);

        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(201, "Modify user", typeof(string))]
        public async Task<IActionResult> ModifyAsync(Guid id, [FromBody] UpdateUserRequest request, CancellationToken token)
        {
            return Ok(await _userService.UpdateAsync(id, request, token));
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(201, "Delete user")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken token)
        {
            return Ok(await _userService.DeleteAsync(id, token));
        }

        //--temp solution for blocking users(by deleting)

        [HttpPost]
        [Route("{id}/action")]
        [SwaggerResponse(201, "Block user")]
        public async Task<IActionResult> BlockAsync(Guid id, CancellationToken token)
        {
            return Ok(await _userService.DeleteAsync(id, token));
        }

    }
}