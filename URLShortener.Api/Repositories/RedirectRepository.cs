using System;
using System.Collections.Generic;
using URLShortener.Api.Models;
using URLShortener.Api.Repositories.Base;

namespace URLShortener.Api.Repositories
{
    public class RedirectRepository : BaseMongoRepository<RedirectModel>, IRedirectRepository
    {
        public RedirectRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }

        public List<RedirectModel> GetAll()
        {
            return GetList();
        }

        public void SaveLog(RedirectModel log)
        {
            try
            {
                Create(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("****** !! Error en logging: " + ex);
            }
        }
    }
}
