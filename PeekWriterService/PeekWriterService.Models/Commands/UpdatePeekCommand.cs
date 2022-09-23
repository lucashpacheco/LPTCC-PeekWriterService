using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Commands
{
    public class UpdatePeekCommand
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public Guid? AuthorId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
