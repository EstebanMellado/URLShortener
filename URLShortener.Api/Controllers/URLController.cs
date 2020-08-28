using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using URLShortener.Api.Models;
using URLShortener.Api.Services;

namespace URLShortener.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private IURLService _urlService;
        private readonly ILogger<URLController> _logger;

        public URLController(IURLService urlService, ILogger<URLController> logger)
        {
            _urlService = urlService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<URLModel> shortUrls = _urlService.GetAll();
            return Ok(shortUrls);
        }

        [HttpGet("{shorturl}", Name = "Get")]
        public IActionResult Get(string shorturl)
        {
            URLModel shortUrl = _urlService.GetShortURL(shorturl);

            if (shortUrl != null)
            {
                return Ok(shortUrl);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShortURLRequest model)
        {
            if (ModelState.IsValid)
            {
                ShortUrlResponse result = _urlService.SaveURL(model);
                if (result != null)
                {
                    _logger.LogInformation($"URL creada: {result.Model.ShortURL} a {result.Model.LongURL}");
                    return Ok(result);
                }
            }

            return BadRequest(ModelState.Values);
        }

        [HttpDelete("{shorturl}", Name = "Delete")]
        public IActionResult Delete(string shorturl)
        {
            ShortUrlResponse result = _urlService.DeleteURL(shorturl);
            if (result != null)
            {
                _logger.LogInformation($"URL eliminada: {shorturl}");
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
