using System.Collections.Generic;
using URLShortener.Api.Models;

namespace URLShortener.Api.Services
{
    public interface IURLService
    {
        IEnumerable<URLModel> GetAll();
        URLModel GetShortURL(string shortUrl);
        ShortUrlResponse SaveURL(ShortURLRequest urlModel);
    }
}
