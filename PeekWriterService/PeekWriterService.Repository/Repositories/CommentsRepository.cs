using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CommentsWriterService.API.Config;
using CommentsWriterService.Repository.Contexts;
using UserService.Model.Domain;
using PeekWriterService.Repository.Contexts;
using PeekWriterService.Models.Domain;
using PeekWriterService.API.Config;

namespace CommentsWriterService.Repository.Repositories
{
    public class CommentsRepository
    {
        public readonly CommentContext _commentsContext;
        public CommentsRepository(IOptions<ConfigDb> options)
        {
            _commentsContext = new CommentContext(options);
        }

        public async Task<bool> Save(CommentsDocument commentsDocument)
        {
            var updateResult = await _commentsContext.Comments.UpdateOneAsync(
                x => x.PeekId == commentsDocument.PeekId,
                Builders<CommentsDocument>
                .Update
                .AddToSet<Comment>("Comments", commentsDocument.Comments[0])
                );

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Update(CommentsDocument commentsDocument)
        {
            var updateResult = await _commentsContext.Comments.UpdateOneAsync(
                x => x.PeekId == commentsDocument.PeekId , 
                Builders<CommentsDocument>
                .Update
                .Set(x => x.Comments.Where(x => x.Id == commentsDocument.Comments[0].Id), commentsDocument.Comments[0].Message)
                );

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid? id)
        {
            var deletedResult = await _commentsContext.Comments.DeleteOneAsync(x => x.Id == id);

            return deletedResult.IsAcknowledged &&
                     deletedResult.DeletedCount > 0;
        }
    }
}
