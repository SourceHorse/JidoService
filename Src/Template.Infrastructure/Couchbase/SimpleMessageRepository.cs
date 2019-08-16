using System;
using System.Collections.Generic;
using System.Text;
using Couchbase.Core;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase.Models;

namespace Template.Infrastructure.Couchbase
{
    class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly IBucket _bucket;

        public SimpleMessageRepository(ITestBucketProvider testBucketProvider)
        {
            _bucket = testBucketProvider.GetBucket();
        }

        /// <inheritdoc />
        public SimpleMessage AddMessage(SimpleMessage simpleMessage)
        {
            // TODO: Implement AutoMapper
            var dbMessage = new SimpleMessageDbModel
            {
                Id = Guid.NewGuid(),
                Title = simpleMessage.Title,
                Body = simpleMessage.Body
            };

            var couchbaseKey = GetCouchbaseKey(dbMessage.Id);
            _bucket.Insert(couchbaseKey, dbMessage);
            var savedDocument = GetMessage(couchbaseKey);

            // TODO: Implement AutoMapper
            return new SimpleMessage
            {
                Id = savedDocument.Id,
                Title = savedDocument.Title,
                Body = savedDocument.Body,
                CreatedOn = savedDocument.CreatedOn
            };
        }

        /// <inheritdoc />
        public SimpleMessage RetrieveMessage(Guid id)
        {
            var document = GetMessage(GetCouchbaseKey(id));

            if (document == null)
            {
                return null;
            }

            // TODO: Implement AutoMapper
            return new SimpleMessage
            {
                Id = document.Id,
                Title = document.Title,
                Body = document.Body,
                CreatedOn = document.CreatedOn
            };
        }

        /// <inheritdoc />
        public SimpleMessage UpdateMessage(Guid id, SimpleMessage simpleMessage)
        {
            var couchbaseKey = GetCouchbaseKey(id);
            var existingDocument = GetMessage(couchbaseKey);

            if (existingDocument == null)
            {
                return null;
            }

            // TODO: Implement AutoMapper
            var dbMessage = new SimpleMessageDbModel
            {
                Id = id,
                Title = simpleMessage.Title,
                Body = simpleMessage.Body,
                CreatedOn = existingDocument.CreatedOn
            };

            _bucket.Replace(GetCouchbaseKey(dbMessage.Id), dbMessage);

            return RetrieveMessage(id);
        }

        private SimpleMessageDbModel GetMessage(string couchbaseKey)
        {
            return _bucket.Get<SimpleMessageDbModel>(couchbaseKey).Value;
        }

        private string GetCouchbaseKey(Guid id)
        {
            return $"SimpleMessage.{id}";
        }
    }
}
