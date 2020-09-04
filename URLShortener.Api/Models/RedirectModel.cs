using MongoDB.Bson.Serialization.Attributes;
using System;
using URLShortener.Api.Models.Base;

namespace URLShortener.Api.Models
{
    public class RedirectModel : MongoBaseModel
    {
        [BsonElement("TimeStamp")]
        public DateTime TimeStamp => DateTime.Now;

        [BsonElement("ShortURL")]
        public string ShortURL { get; set; }

        [BsonElement("LongURL")]
        public string LongURL { get; set; }
    }
}
