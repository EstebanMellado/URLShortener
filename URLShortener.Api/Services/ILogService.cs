using URLShortener.Api.Models;

namespace URLShortener.Api.Services
{
    public interface ILogService
    {
        void LogInfo(RedirectModel log);
    }
}
