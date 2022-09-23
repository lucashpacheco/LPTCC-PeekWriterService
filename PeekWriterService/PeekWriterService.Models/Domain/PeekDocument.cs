using System;
using MongoDB.Bson.Serialization.Attributes;
using PeekWriterService.Models.Commands;

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

        public PeekDocument(CreatePeekCommand createPeekCommand)
        {
            this.Id = createPeekCommand.Id;
            this.AuthorId = createPeekCommand.AuthorId;
            this.Message = createPeekCommand.Message;
            this.CreatedDate = DateTime.UtcNow;
        }

        public PeekDocument(UpdatePeekCommand updatePeekCommand)
        {
            this.Id = updatePeekCommand.Id;
            this.AuthorId = updatePeekCommand.AuthorId;  
            this.Message = updatePeekCommand.Message;
            this.CreatedDate = DateTime.UtcNow;
        }

        public PeekDocument()
        {
        }
    }
}
