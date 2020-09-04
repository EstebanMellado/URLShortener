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
        private readonly ILogService _logService;

        public RedirectController(IURLService urlService, ILogger<RedirectController> logger, ILogService logService)
        {
            _urlService = urlService;
            _logger = logger;
            _logService = logService;
        }

        [HttpGet("{shorturl}", Name = "Redirect")]
        public IActionResult Get(string shorturl)
        {
            URLModel urlModel = _urlService.GetShortURL(shorturl);
            if (urlModel != null)
            {
                _logger.LogInformation($"Acceso a Redirect de {urlModel.ShortURL} a {urlModel.LongURL}");
                //_logService.LogInfo(new RedirectModel() { ShortURL = urlModel.ShortURL, LongURL = urlModel.LongURL });
                return Redirect(urlModel.LongURL);
            }

            return NotFound();
        }
    }
}
