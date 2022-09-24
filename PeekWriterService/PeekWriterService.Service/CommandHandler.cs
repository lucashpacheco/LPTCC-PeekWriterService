using System.Collections.Generic;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Domain;
using PeekWriterService.Models.Responses.Common;

namespace PeekWriterService.Service
{
    public class CommandHandler
    {
        public ResponseBase<bool> Create(CreatePeekCommand createPeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(createPeekCommand);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Create(CreateCommentCommand createCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(createCommentCommand);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Create(CreateLikeCommand createLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new LikesDocument(createLikeCommand);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Delete(DeletePeekCommand deletePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            
            //TODO apagar likes , comments e peek

            return response;
        }

        public ResponseBase<bool> Delete(DeleteCommentCommand deleteCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Delete(DeleteLikeCommand deleteLikeCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Update(UpdatePeekCommand updatePeekCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new PeekDocument(updatePeekCommand);

            //TODO chama a repository

            return response;
        }

        public ResponseBase<bool> Update(UpdateCommentCommand updateCommentCommand)
        {
            var response = new ResponseBase<bool>(success: false, errors: new List<string>(), data: false);

            var document = new CommentsDocument(updateCommentCommand);

            //TODO chama a repository

            return response;
        }

    }
}
