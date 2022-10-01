using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekWriterService.API.Config;
using PeekWriterService.Models.Domain;
using PeekWriterService.Repository.Contexts;
using PeekWriterService.Service.Interfaces;

namespace PeekWriterService.Repository.Repositories
{
    public class CommentsRepository : ICommentsRepository
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
                Builders<CommentsDocument>.Update
                                          .AddToSetEach("Comments", commentsDocument.Comments),
                new UpdateOptions { IsUpsert = true});

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0 || 
                     updateResult.IsAcknowledged && 
                     !String.IsNullOrEmpty(updateResult.UpsertedId.ToString());
        }

        //public async Task<bool> Update(CommentsDocument commentsDocument)
        //{
        //    var updateResult = await _commentsContext.Comments.UpdateOneAsync(
        //        x => x.PeekId == commentsDocument.PeekId && x.Id == commentsDocument.Comments[0].Id, 
        //        Builders<CommentsDocument>
        //        .Update
        //        .Set(x => x.Comments.Find(x => ), commentsDocument.Comments[0].Message)
        //        );

        //    return updateResult.IsAcknowledged &&
        //             updateResult.ModifiedCount > 0;
        //}

        public async Task<bool> Delete(Guid? id)
        {
            var deletedResult = await _commentsContext.Comments.DeleteOneAsync(x => x.PeekId == id);

            return deletedResult.IsAcknowledged &&
                     deletedResult.DeletedCount > 0;
        }
    }
}
