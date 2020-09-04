using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Api.Models;
using URLShortener.Api.Services;

namespace URLShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IRedirectService _redirectService;

        public StatisticController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<StatisticModel> statistics = _redirectService.GetStatistics();
            return Ok(statistics);
        }
    }
}
