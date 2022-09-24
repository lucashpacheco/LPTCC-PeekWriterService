using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Domain
{
    public class Comment
    {
        [BsonRequired]
        public Guid? Id { get; set; }

        [BsonRequired]
        public Guid? AuthorId { get; set; }
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