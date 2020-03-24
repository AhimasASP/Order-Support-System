using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace OSS.WebApplication.Controllers
{
	[Route("[Controller]/[action]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}


		[HttpGet]
		[Route("{id}")]
		[Authorize]
		[SwaggerResponse(200, "Show user details", typeof(string))]
		public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
		{
			return Ok(await _userService.GetAsync(id, cancellationToken));
		}

		[HttpGet]
		[SwaggerResponse(200, "Show users list", typeof(string))]
		[Authorize]
		[SwaggerResponse(200, "Show user list")]
		public async Task<IActionResult> GetAllAsync(CancellationToken token)
		{
			return Ok(await _userService.GetListAsync(token));
		}

		[HttpPost]
        [SwaggerResponse(201, "Add new user", typeof(string))]
		[Authorize]
        public async Task<IActionResult> CreateAsync([FromBody]CreateUserRequest request, CancellationToken cancellationToken)
		{
			return Ok(await _userService.CreateAsync(request, cancellationToken));
		}

		[HttpPut]
		[Route("{id}")]
        [SwaggerResponse(201, "Modify user", typeof(string))]
		[Authorize]
        public async Task<IActionResult> ModifyAsync(string id, [FromBody] UpdateUserRequest request, CancellationToken token)
		{
			return Ok(await _userService.UpdateAsync(request, token));
		}

		[HttpDelete]
		[Route("{id}")]
		[SwaggerResponse(201, "Delete user")]
		[Authorize]
		public async Task<IActionResult> DeleteAsync(string id, CancellationToken token)
		{
			return Ok(await _userService.DeleteAsync(id, token));
		}

		//--temp solution for blocking users(by deleting)

		[HttpPost]
		[Route("{id}/action")]
		[SwaggerResponse(201, "Block user")]
		public async Task<IActionResult> BlockAsync(string id, CancellationToken token)
		{
			return Ok(await _userService.DeleteAsync(id, token));
		}

    }
}