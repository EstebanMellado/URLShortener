using URLShortener.Api.Models;

namespace URLShortener.Api.Repositories
{
    public interface ILogRepository
    {
        void SaveLog(RedirectModel log);
    }
}
