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
            var savedDocument = _bucket.GetDocument<SimpleMessageDbModel>(couchbaseKey).Content;

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
            var document = _bucket.GetDocument<SimpleMessageDbModel>(GetCouchbaseKey(id)).Content;

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
        public SimpleMessage UpdateMessage(SimpleMessage simpleMessage)
        {
            // TODO: Implement AutoMapper
            var dbMessage = new SimpleMessageDbModel
            {
                Id = simpleMessage.Id,
                Title = simpleMessage.Title,
                Body = simpleMessage.Body
            };

            var updatedDocument = _bucket.Replace(GetCouchbaseKey(dbMessage.Id), dbMessage).Value;

            if (updatedDocument == null)
            {
                return null;
            }

            // TODO: Implement AutoMapper
            return new SimpleMessage
            {
                Id = updatedDocument.Id,
                Title = updatedDocument.Title,
                Body = updatedDocument.Body,
                CreatedOn = updatedDocument.CreatedOn
            };
        }

        private string GetCouchbaseKey(Guid id)
        {
            return $"SimpleMessage.{id}";
        }
    }
}
