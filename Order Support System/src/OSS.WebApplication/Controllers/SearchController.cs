using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OSS.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class SearchController : Controller
    {
       
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("{param}")]
        [SwaggerResponse(200, "Search by param", typeof(string))]
        public async Task<IActionResult> SearchAsync(string param, CancellationToken token)
        {
            return Ok(await _searchService.SearchAsync(param, token));
        }

    }
}