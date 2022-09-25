using System.Threading.Tasks;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Common.Responses;

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
