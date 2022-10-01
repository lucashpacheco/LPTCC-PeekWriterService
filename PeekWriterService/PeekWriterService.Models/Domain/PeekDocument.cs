using System;
using MongoDB.Bson.Serialization.Attributes;
using PeekWriterService.Models.Commands;

namespace PeekWriterService.Models.Domain
{
    public class PeekDocument
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonRequired]
        public Guid AuthorId { get; set; }
        [BsonRequired]
        public string Message { get; set; }
        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        public PeekDocument(CreatePeekCommand createPeekCommand)
        {
            this.Id = (Guid)createPeekCommand.Id;
            this.AuthorId = (Guid)createPeekCommand.AuthorId;
            this.Message = createPeekCommand.Message;
            this.CreatedDate = DateTime.UtcNow;
        }

        public PeekDocument(UpdatePeekCommand updatePeekCommand)
        {
            this.Id = (Guid)updatePeekCommand.Id;
            this.AuthorId = (Guid)updatePeekCommand.AuthorId;  
            this.Message = updatePeekCommand.Message;
            this.CreatedDate = DateTime.UtcNow;
        }

        public PeekDocument()
        {
        }
    }
}
