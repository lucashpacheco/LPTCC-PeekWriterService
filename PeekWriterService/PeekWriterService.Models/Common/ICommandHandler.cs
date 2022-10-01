using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekWriter.Commands;

namespace PeekWriterService.Models.Common
{
    public interface ICommandHandler
    {
        Task<ResponseBase<bool>> Create(CreatePeekCommand createPeekCommand);
        Task<ResponseBase<bool>> Create(CreateCommentCommand createPeekCommand);
        Task<ResponseBase<bool>> Create(CreateLikeCommand createPeekCommand);
        Task<ResponseBase<bool>> Delete(DeletePeekCommand deletePeekCommand);
        Task<ResponseBase<bool>> Delete(DeleteCommentCommand deletePeekCommand);
        Task<ResponseBase<bool>> Delete(DeleteLikeCommand deletePeekCommand);
        Task<ResponseBase<bool>> Update(UpdatePeekCommand updatePeekCommand);
        Task<ResponseBase<bool>> Update(UpdateCommentCommand updatePeekCommand);

    }
}
