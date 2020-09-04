using URLShortener.Api.Models;
using URLShortener.Api.Repositories;

namespace URLShortener.Api.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void LogInfo(RedirectModel log)
        {
            _logRepository.SaveLog(log);
        }
    }
}
