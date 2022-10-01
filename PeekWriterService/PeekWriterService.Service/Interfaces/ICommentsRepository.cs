using System;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;

namespace PeekWriterService.Service.Interfaces
{
    public interface ICommentsRepository
    {
        Task<bool> Save(CommentsDocument commentsDocument);
        Task<bool> Delete(Guid? id);
    }
}
