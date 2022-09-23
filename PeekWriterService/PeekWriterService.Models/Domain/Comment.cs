using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Domain
{
    public class Comment
    {
        [BsonRequired]
        public int AuthorId { get; set; }
        [BsonRequired]
        public string Message { get; set; }
        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        public Comment (DateTime createdDate)
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}