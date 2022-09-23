using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace PeekWriterService.Models.Commands
{
    public class DeletePeekCommand
    {
        [Required]
        public Guid? Id { get; set; }
    }
}
