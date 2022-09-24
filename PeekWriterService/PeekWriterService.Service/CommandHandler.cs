using System.Collections.Generic;
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

        public ResponseBase<bool> Create(CreatePeekCommand createPeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(createPeekCommand);

            var result = _peekRepository.Save(document);

            return response;
        }

        public ResponseBase<bool> Create(CreateCommentCommand createCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(createCommentCommand);

            var result = _commentsRepository.Save(document);

            return response;
        }

        public ResponseBase<bool> Create(CreateLikeCommand createLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new LikesDocument(createLikeCommand);

            var result = _likesRepository.Save(document);

            return response;
        }

        public ResponseBase<bool> Delete(DeletePeekCommand deletePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);


            var result = _peekRepository.Delete(deletePeekCommand.Id);


            return response;
        }

        public ResponseBase<bool> Delete(DeleteCommentCommand deleteCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var result = _commentsRepository.Delete(deleteCommentCommand.CommentId);

            return response;
        }

        public ResponseBase<bool> Delete(DeleteLikeCommand deleteLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var result = _likesRepository.Delete(deleteLikeCommand.PeekId);

            return response;
        }

        public ResponseBase<bool> Update(UpdatePeekCommand updatePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(updatePeekCommand);

            var result = _peekRepository.Update(document);

            return response;
        }

        public ResponseBase<bool> Update(UpdateCommentCommand updateCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(updateCommentCommand);

            //var result = _commentsRepository.Update(document);

            return response;
        }

    }
}
