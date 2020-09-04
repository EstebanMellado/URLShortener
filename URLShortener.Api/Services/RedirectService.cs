using System.Collections.Generic;
using System.Linq;
using URLShortener.Api.Models;
using URLShortener.Api.Repositories;

namespace URLShortener.Api.Services
{
    public class RedirectService : IRedirectService
    {
        private readonly IRedirectRepository _logRepository;

        public RedirectService(IRedirectRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public IEnumerable<StatisticModel> GetStatistics()
        {
            var list = new List<StatisticModel>();
            var collection = _logRepository.GetAll();
            foreach (var line in collection.GroupBy(info => info.ShortURL)
                        .Select(group => new
                        {
                            Metric = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Metric))
                {
                list.Add(new StatisticModel { ShortURL = line.Metric, Count = line.Count });
            }
            return list;
        }

        public void SaveInfo(RedirectModel log)
        {
            _logRepository.SaveLog(log);
        }
    }
}
