using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Domain
{
    public class LikesDocument
    {
        [BsonId]
        public Guid PeekId { get; set; }
        [BsonRequired]
        public List<Like> Likes { get; set; }
    }
}
