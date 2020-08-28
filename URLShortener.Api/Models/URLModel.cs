using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using URLShortener.Api.Models.Base;
using static URLShortener.Api.Validators.URLValidator;

namespace URLShortener.Api.Models
{
    public class URLModel : MongoBaseModel
    {
        [BsonElement("ShortURL")]
        public string ShortURL { get; set; }

        [BsonElement("LongURL")]
        public string LongURL { get; set; }

        [BsonElement("CreateDate")]
        public DateTime CreateDate { get; set; }
    }

    public class ShortURLRequest
    {
        [Required]
        [CheckUrlValid(ErrorMessage = "Url no valida")]
        public string LongURL { get; set; }

        public DateTime TimeStamp => DateTime.Now;
    }

    public class ShortUrlResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public URLModel Model { get; set; }
    }
}
