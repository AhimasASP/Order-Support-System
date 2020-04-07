using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSS.Domain.Common.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace OSS.WebApplication.Controllers
{
    [Route("[controller]/")]

    public class EventController : Controller
    {
        [HttpGet]
        [SwaggerResponse(200, "Show events list", typeof(string))]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "Show event details", typeof(string))]
        public IActionResult ShowDetails(string id)
        {
            return Ok();
        }
    }
}