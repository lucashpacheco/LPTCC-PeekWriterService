using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using PeekWriterService.Models.Domain;

namespace PeekWriterService.Models.Commands
{
    public class DeleteCommentCommand
    {
        [Required]
        public Guid? PeekId { get; set; }
        [Required]
        public Guid? CommentId { get; set; }
    }
}
