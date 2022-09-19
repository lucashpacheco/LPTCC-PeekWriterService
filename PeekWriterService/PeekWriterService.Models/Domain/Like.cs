using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Domain
{
    public class Like
    {
        [BsonRequired]
        public int UserId { get; set; }
        [BsonRequired]
        public DateTime CreatedDate { get; set; }

    }
}