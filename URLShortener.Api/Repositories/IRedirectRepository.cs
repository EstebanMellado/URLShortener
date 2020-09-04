using URLShortener.Api.Models;

namespace URLShortener.Api.Repositories
{
    public interface IRedirectRepository
    {
        void SaveLog(RedirectModel log);
    }
}
