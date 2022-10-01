﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
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

            var test = updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0 ||
                     updateResult.IsAcknowledged &&
                     !String.IsNullOrEmpty(updateResult.UpsertedId.ToString());

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0 ||
                     updateResult.IsAcknowledged &&
                     !String.IsNullOrEmpty(updateResult.UpsertedId.ToString());
        }

        public async Task<bool> Delete(Guid? id)
        {
            var deletedResult = await _likesContext.Likes.DeleteOneAsync(x => x.PeekId == id);

            return deletedResult.IsAcknowledged &&
                     deletedResult.DeletedCount > 0;
        }
    }
}
