using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using OSS.Model.Api.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "Show image", typeof(string))]
        public async Task<IActionResult> GetAsync(string id, CancellationToken token)
        {
            return Ok(await _imageService.GetAsync(id, token));
        }

        [HttpPost]
        [SwaggerResponse(201, "Add new image")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateImageRequest request, CancellationToken token)
        {
            return Ok(await _imageService.CreateAsync(request, token));
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(201, "Delete image")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken token)
        {
            return Ok(await _imageService.DeleteAsync(id, token));
        }
    }
}