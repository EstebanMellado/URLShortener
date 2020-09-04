using System.Collections.Generic;
using URLShortener.Api.Models;

namespace URLShortener.Api.Services
{
    public interface IRedirectService
    {
        void SaveInfo(RedirectModel log);
        IEnumerable<StatisticModel> GetStatistics();
    }
}
