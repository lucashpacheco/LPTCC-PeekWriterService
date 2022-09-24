using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeekWriterService.Models.Domain;

namespace PeekWriterService.Service.Interfaces
{
    public interface ICommentsRepository
    {
        Task<bool> Save(CommentsDocument commentsDocument);
        Task<bool> Delete(Guid? id);
    }
}
