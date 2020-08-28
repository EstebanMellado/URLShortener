using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using URLShortener.Api.Models;
using URLShortener.Api.Services;

namespace URLShortener.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private IURLService _urlService;
        private readonly ILogger<RedirectController> _logger;

        public RedirectController(IURLService urlService, ILogger<RedirectController> logger)
        {
            _urlService = urlService;
            _logger = logger;
        }

        [HttpGet("{shorturl}", Name = "Redirect")]
        public IActionResult Get(string shorturl)
        {
            URLModel shortUrl = _urlService.GetShortURL(shorturl);
            if (shortUrl != null)
            {
                _logger.LogInformation($"Acceso a rediccion de {shorturl} a {shortUrl.LongURL}");
                return Redirect(shortUrl.LongURL);
            }

            return NotFound();
        }
    }
}
