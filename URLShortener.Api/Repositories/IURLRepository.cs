using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Api.Models;

namespace URLShortener.Api.Repositories
{
    public interface IURLRepository
    {
        IEnumerable<URLModel> GetAll();
        URLModel GetURLByShortUrl(string shortUrl);
        URLModel GetURLByLongUrl(string longUrl);
        URLModel Save(URLModel urlModel);
    }
}
