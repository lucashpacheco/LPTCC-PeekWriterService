using System.Collections.Generic;
using System.Threading.Tasks;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Common;
using PeekWriterService.Models.Common.Responses;
using PeekWriterService.Models.Domain;
using PeekWriterService.Service.Interfaces;

namespace PeekWriterService.Service
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ILikesRepository _likesRepository;
        private readonly IPeekRepository _peekRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommandHandler(IPeekRepository peekRepository, ICommentsRepository commentsRepository , ILikesRepository likesRepository)
        {
            _peekRepository = peekRepository;
            _commentsRepository = commentsRepository;
            _likesRepository = likesRepository;
        }

        public async Task<ResponseBase<bool>> Create(CreatePeekCommand createPeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(createPeekCommand);

            var result = await _peekRepository.Save(document);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Create(CreateCommentCommand createCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(createCommentCommand);

            var result = await _commentsRepository.Save(document);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Create(CreateLikeCommand createLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new LikesDocument(createLikeCommand);

            var result = await _likesRepository.Save(document);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Delete(DeletePeekCommand deletePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);


            var result = await _peekRepository.Delete(deletePeekCommand.Id);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Delete(DeleteCommentCommand deleteCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var result = await _commentsRepository.Delete(deleteCommentCommand.CommentId);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Delete(DeleteLikeCommand deleteLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var result = await _likesRepository.Delete(deleteLikeCommand.PeekId);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Update(UpdatePeekCommand updatePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(updatePeekCommand);

            var result = await _peekRepository.Update(document);

            if (!result)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<bool>> Update(UpdateCommentCommand updateCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(updateCommentCommand);

            //var result = await _commentsRepository.Update(document);

            //if (!result)
            //    return response;

            //response.Success = true;
            //response.Data = result;

            return response;
        }

    }
}
