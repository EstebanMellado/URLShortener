using System.Collections.Generic;
using URLShortener.Api.Mappings;
using URLShortener.Api.Models;
using URLShortener.Api.Repositories;

namespace URLShortener.Api.Services
{
    public class URLService : IURLService
    {
        private readonly IURLRepository _urlRepository;

        public URLService(IURLRepository shortUrlRepository)
        {
            _urlRepository = shortUrlRepository;
        }

        public ShortUrlResponse DeleteURL(string shortUrl)
        {
            bool result = _urlRepository.DeleteUrl(shortUrl);
            return new ShortUrlResponse
            {
                Model = null,
                Success = result,
                Message = result ? $"URL {shortUrl} eliminada" : $"No se pudo eliminar la URL {shortUrl}"
            };
        }

        public IEnumerable<URLModel> GetAll()
        {
            return _urlRepository.GetAll();
        }

        public URLModel GetLongURL(string longurl)
        {
            return _urlRepository.GetURLByLongUrl(longurl);
        }

        public URLModel GetShortURL(string shortUrl)
        {
            return _urlRepository.GetURLByShortUrl(shortUrl);
        }

        public ShortUrlResponse SaveURL(ShortURLRequest urlModel)
        {
            URLModel exitingUrl = _urlRepository.GetURLByLongUrl(urlModel.LongURL);
            if (exitingUrl != null)
            {
                return new ShortUrlResponse { Model = exitingUrl, Success = true, Message = "Se encontro una URL" };
            }
            else
            {
                URLModel savedModel = _urlRepository.SaveUrl(URLMapper.MapRequestModelToDBModel(urlModel));

                return new ShortUrlResponse
                {
                    Model = savedModel,
                    Success = true,
                    Message = "URL guardada"
                };
            }
        }
    }
}
