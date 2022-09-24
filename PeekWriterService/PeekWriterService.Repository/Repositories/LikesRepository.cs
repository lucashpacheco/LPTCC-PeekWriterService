using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekWriterService.API.Config;
using PeekWriterService.Models.Domain;
using PeekWriterService.Repository.Contexts;
using PeekWriterService.Service.Interfaces;

namespace LikesWriterService.Repository.Repositories
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
                Builders<LikesDocument>
                .Update
                .AddToSetEach( "Likes" , likesDocument.Likes)
                );

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid? id)
        {
            var deletedResult = await _likesContext.Likes.DeleteOneAsync(x => x.PeekId == id);

            return deletedResult.IsAcknowledged &&
                     deletedResult.DeletedCount > 0;
        }
    }
}
