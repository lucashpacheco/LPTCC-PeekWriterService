using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekWriter.Commands;
using Peek.Framework.UserService.Domain;
using PeekWriterService.API.Config;
using PeekWriterService.Repository.Contexts;
using PeekWriterService.Service.Interfaces;

namespace PeekWriterService.Repository.Repositories
{
    public class LikesRepository : ILikesRepository
    {
        public readonly LikeContext _likesContext;
        public LikesRepository(IOptions<ConfigDb> options)
        {
            _likesContext = new LikeContext(options);
        }

        public async Task<bool> Save(LikesDocument LikesDocument)
        {
            await _likesContext.Likes.InsertOneAsync(LikesDocument);

            return true;
        }

        public async Task<bool> Update(LikesDocument likesDocument)
        {
            var updateResult = await _likesContext.Likes.UpdateOneAsync(
                x => x.PeekId == likesDocument.PeekId,
                Builders<LikesDocument>.Update
                                       .AddToSetEach("Likes", likesDocument.Likes),
                new UpdateOptions { IsUpsert = true }
                );

            //var test = updateResult.IsAcknowledged &&
            //         updateResult.ModifiedCount > 0 ||
            //         updateResult.IsAcknowledged &&
            //         !String.IsNullOrEmpty(updateResult.UpsertedId.ToString());

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0 ||
                     updateResult.IsAcknowledged &&
                     !String.IsNullOrEmpty(updateResult.UpsertedId.ToString());
        }

        public async Task<bool> Delete(DeleteLikeCommand deleteLikeCommand)
        {
            var filter = Builders<LikesDocument>.Filter.Where(x => x.PeekId == deleteLikeCommand.PeekId);
            var update = Builders<LikesDocument>.Update.PullFilter(y => y.Likes, builder => builder.UserId == deleteLikeCommand.UserId);
            var result = await _likesContext.Likes.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;

            //var updateResult = await _likesContext.Likes.UpdateOneAsync(
            //    x => x.PeekId == id,
            //    Builders<LikesDocument>.Update
            //                           .Pull("Likes", Query.EQ("UserId", productId)),
            //    new UpdateOptions { IsUpsert = true }
            //    );

            //var deletedResult = await _likesContext.Likes.DeleteOneAsync(x => x.PeekId == id);

            //return deletedResult.IsAcknowledged &&
            //         deletedResult.DeletedCount > 0;
        }
    }
}
