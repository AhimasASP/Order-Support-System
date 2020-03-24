using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Interfaces.Services;

namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [SwaggerResponse(200, "Show catalog", typeof(string))]
        public async Task<IActionResult> Index(CancellationToken token)
        {
            return Ok(await _itemService.GetAllAsync(token));
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "Show item", typeof(string))]
        public async Task<IActionResult> GetAsync(string id, CancellationToken token)
        {
            return Ok(await _itemService.GetAsync(id, token));
        }
        
        [HttpPost]
        [SwaggerResponse(201, "Add new item")]
        public async Task<IActionResult>  CreateAsync([FromBody]CreateItemRequest request, CancellationToken token)
        {
            return Ok(await _itemService.CreateAsync(request, token));
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(201, "Modify item")]
        public async Task<IActionResult> ModifyAsync([FromBody]UpdateItemRequest request, CancellationToken token)
        {
            return Ok(await _itemService.UpdateAsync(request, token));
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(201, "Delete item")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken token)
        {
            return Ok(await _itemService.DeleteAsync(id, token));
        }
    }
}