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

        public void SaveInfo(RedirectModel log)
        {
            _logRepository.SaveLog(log);
        }
    }
}
