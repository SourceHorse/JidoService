using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Couchbase.Core;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase.Models;

namespace Template.Infrastructure.Couchbase
{
    class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly IBucket _bucket;
        private readonly IMapper _mapper;

        public SimpleMessageRepository(ITestBucketProvider testBucketProvider, IMapper mapper)
        {
            _bucket = testBucketProvider.GetBucket();
            _mapper = mapper;
        }

        /// <inheritdoc />
        public SimpleMessage AddMessage(SimpleMessageCreateRequest simpleMessageCreate)
        {
            var dbMessage = _mapper.Map<SimpleMessageDbModel>(simpleMessageCreate);

            var couchbaseKey = GetCouchbaseKey(dbMessage.Id);
            _bucket.Insert(couchbaseKey, dbMessage);
            var savedDocument = GetMessage(couchbaseKey);

            return _mapper.Map<SimpleMessage>(savedDocument);
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
                CreatedOn = document.CreatedOn,
                Enabled = document.Enabled
            };
        }

        /// <inheritdoc />
        public SimpleMessage UpdateMessage(Guid id, SimpleMessage simpleMessage)
        {
            var couchbaseKey = GetCouchbaseKey(id);
            var existingDocument = GetMessage(couchbaseKey);

            if (existingDocument == null || !existingDocument.Enabled)
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

        /// <inheritdoc />
        public void DisableMessage(Guid id)
        {
            var couchbaseKey = GetCouchbaseKey(id);
            var message = GetMessage(couchbaseKey);
            message.Enabled = false;

            _bucket.Replace(couchbaseKey, message);
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
