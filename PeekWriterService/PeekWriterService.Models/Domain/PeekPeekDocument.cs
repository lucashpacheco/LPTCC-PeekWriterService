using System;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Model.Domain
{
    public class PeekDocument
    {
        [BsonId]
        public Guid? Id { get; set; }
        [BsonRequired]
        public Guid? AuthorId { get; set; }
        [BsonRequired]
        public string Message { get; set; }
        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        public PeekDocument(Guid? id , Guid? authorId, string message)
        {
            this.Id = id;
            this.AuthorId = authorId;  
            this.Message = message;
            this.CreatedDate = DateTime.UtcNow;
        }

        public PeekDocument()
        {
        }
    }
}
