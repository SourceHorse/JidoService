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
        public void AddMessage(SimpleMessage simpleMessage)
        {
            // TODO: Implement AutoMapper
            var dbMessage = new SimpleMessageDbModel
            {
                Id = simpleMessage.Id,
                Title = simpleMessage.Title,
                Message = simpleMessage.Message
            };

            _bucket.Upsert($"SimpleMessage.{dbMessage.Id}", dbMessage);
        }
    }
}
