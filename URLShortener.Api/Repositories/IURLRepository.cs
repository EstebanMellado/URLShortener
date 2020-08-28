using System.Collections.Generic;
using URLShortener.Api.Models;

namespace URLShortener.Api.Repositories
{
    public interface IURLRepository
    {
        IEnumerable<URLModel> GetAll();
        URLModel GetURLByShortUrl(string shortUrl);
        URLModel GetURLByLongUrl(string longUrl);
        URLModel SaveUrl(URLModel urlModel);
        bool DeleteUrl(string shortUrl);
    }
}
