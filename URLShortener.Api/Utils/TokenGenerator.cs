using System;
using System.Linq;

namespace URLShortener.Api.Utils
{
    public static class TokenGenerator
    {
        public static string GenerateShortUrl()
        {
            string newURl = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => newURl += Convert.ToChar(i));
            string token = newURl.Substring(new Random().Next(0, newURl.Length), new Random().Next(2, 6));

            return token;
        }
    }
}
