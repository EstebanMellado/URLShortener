using System;
using URLShortener.Api.Models;
using URLShortener.Api.Repositories.Base;

namespace URLShortener.Api.Repositories
{
    public class LogRepository : BaseMongoRepository<RedirectModel>, ILogRepository
    {
        public LogRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }

        public void SaveLog(RedirectModel log)
        {
            try
            {
                this.Create(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("****** !! Error en logging: " + ex);
            }
        }
    }
}
