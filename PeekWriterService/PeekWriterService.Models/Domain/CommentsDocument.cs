using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using PeekWriterService.Models.Commands;

namespace PeekWriterService.Models.Domain
{
    public class CommentsDocument
    {
        [BsonId]
        public Guid PeekId { get; set; }

        [BsonRequired]
        public List<Comment> Comments { get; set; }

        public CommentsDocument(CreateCommentCommand createCommentCommand)
        {
            PeekId = createCommentCommand.PeekId;
            Comments = new List<Comment>();
            Comments.Add(createCommentCommand.Comment);
        }
        public CommentsDocument(UpdateCommentCommand updateCommentCommand)
        {
            PeekId = updateCommentCommand.PeekId;
            Comments = new List<Comment>();
            Comments.Add(updateCommentCommand.Comment);
        }
    }
}
