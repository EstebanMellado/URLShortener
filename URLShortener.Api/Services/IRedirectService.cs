using URLShortener.Api.Models;

namespace URLShortener.Api.Services
{
    public interface IRedirectService
    {
        void SaveInfo(RedirectModel log);
    }
}
