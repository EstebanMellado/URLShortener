using MongoDB.Bson;

namespace URLShortener.Api.Models.Base
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }
    }
}
