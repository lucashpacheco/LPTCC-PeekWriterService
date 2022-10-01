﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
using PeekWriterService.API.Config;

namespace PeekWriterService.Repository.Contexts
{
    public class PeekContext
    {
        public readonly IMongoDatabase _mongoDatabase;
        public PeekContext(IOptions<ConfigDb> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<PeekDocument> Peek
        {
            get
            {
                return _mongoDatabase.GetCollection<PeekDocument>("PeekDocument");
            }
        }
    }
}
