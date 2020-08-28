using System;
using URLShortener.Api.Models;
using URLShortener.Api.Utils;

namespace URLShortener.Api.Mappings
{
    public static class URLMapper
    {
        public static URLModel MapRequestModelToDBModel(ShortURLRequest requestModel)
        {
            URLModel result = new URLModel
            {
                CreateDate = DateTime.Now,
                LongURL = requestModel.LongURL
            };

            result.ShortURL = TokenGenerator.GenerateShortUrl();

            return result;
        }
    }
}
