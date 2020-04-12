using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;


namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [SwaggerResponse(200, "Get orders list")]
        public async Task<IActionResult> Index(CancellationToken token)
        {
            return Ok(await _orderService.GetListAsync(token));
        }

        [HttpGet]
        [SwaggerResponse(200, "Get designer's order list")]
        public async Task<IActionResult> DesignerOrders(CancellationToken token)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "Show details", typeof(string))]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken token)
        {
            return Ok(await _orderService.GetAsync(id, token));
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(201, "Add new order")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateOrderRequest request, CancellationToken token)
        {
            return Ok(await _orderService.CreateAsync(request, token));
        }

    
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(201, "Modify order")]
        public async Task<IActionResult> ModifyAsync(Guid id, [FromBody]UpdateOrderRequest request,
            CancellationToken token)
        {
            return Ok(await _orderService.UpdateAsync(id, request, token));
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(201, "Delete order")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            return Ok(await _orderService.DeleteAsync(id, token));
        }

    }
}