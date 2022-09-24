﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekWriterService.API.Config;
using PeekWriterService.Models.Domain;
using PeekWriterService.Repository.Contexts;
using PeekWriterService.Service.Interfaces;

namespace PeekWriterService.Repository.Repositories
{
    public class PeekRepository : IPeekRepository
    {
        public readonly PeekContext _peekContext;
        public PeekRepository(IOptions<ConfigDb> options)
        {
            _peekContext = new PeekContext(options);
        }

        public async Task<bool> Save(PeekDocument peekDocument)
        {
            await _peekContext.Peek.InsertOneAsync(peekDocument);

            return true;
        }

        public async Task<bool> Update(PeekDocument peekDocument)
        {
            var updateResult = await _peekContext.Peek.UpdateOneAsync(
                x => x.Id == peekDocument.Id , 
                Builders<PeekDocument>
                .Update
                .Set(x => x.Message, peekDocument.Message)
                );

            return updateResult.IsAcknowledged &&
                     updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid? id)
        {
            var deletedResult = await _peekContext.Peek.DeleteOneAsync(x => x.Id == id);

            return deletedResult.IsAcknowledged &&
                     deletedResult.DeletedCount > 0;
        }
    }
}