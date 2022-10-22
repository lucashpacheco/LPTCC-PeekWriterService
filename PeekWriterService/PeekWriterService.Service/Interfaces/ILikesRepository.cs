using System;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekWriter.Commands;

namespace PeekWriterService.Service.Interfaces
{
    public interface ILikesRepository
    {
        Task<bool> Save(LikesDocument commentsDocument);
        Task<bool> Update(LikesDocument commentsDocument);
        Task<bool> Delete(DeleteLikeCommand deleteLikeCommand);
    }
}
