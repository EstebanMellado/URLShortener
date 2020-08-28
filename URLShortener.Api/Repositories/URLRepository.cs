using System;
using System.Collections.Generic;
using URLShortener.Api.Models;
using URLShortener.Api.Repositories.Base;

namespace URLShortener.Api.Repositories
{
    public class URLRepository : BaseMongoRepository<URLModel>, IURLRepository
    {

        public URLRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {

        }
        public IEnumerable<URLModel> GetAll()
        {
            return GetList();
        }

        public URLModel GetURLByShortUrl(string shortUrl)
        {
            return GetBy(c => c.ShortURL == shortUrl);
        }


        public URLModel GetURLByLongUrl(string longUrl)
        {
            return GetBy(c => c.LongURL == longUrl);
        }

        public URLModel Save(URLModel model)
        {
            try
            {
                this.Create(model);
            }
            catch (Exception)
            {
                return null;
            }

            return model;
        }
    }
}
