using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using PeekWriterService.Models.Commands;

namespace PeekWriterService.Models.Domain
{
    public class LikesDocument
    {
        [BsonId]
        public Guid? PeekId { get; set; }
        [BsonRequired]
        public List<Like> Likes { get; set; }

        public LikesDocument(CreateLikeCommand createLikeCommand)
        {
            PeekId = createLikeCommand.PeekId;
            Likes = new List<Like>();
            Likes.Add(createLikeCommand.Like);

        }
    }
}
