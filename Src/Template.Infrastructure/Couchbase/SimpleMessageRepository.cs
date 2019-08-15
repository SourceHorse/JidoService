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

            var couchbaseKey = $"SimpleMessage.{dbMessage.Id}";
            _bucket.Upsert(couchbaseKey, dbMessage);
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

        public SimpleMessage RetrieveMessage(Guid id)
        {
            var couchbaseKey = $"SimpleMessage.{id}";
            var document = _bucket.GetDocument<SimpleMessageDbModel>(couchbaseKey).Content;

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
    }
}
