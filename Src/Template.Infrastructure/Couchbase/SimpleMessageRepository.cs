using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Core;
using Template.Domain.Couchbase;
using Template.Domain.Models;
using Template.Infrastructure.Couchbase.Models;

namespace Template.Infrastructure.Couchbase
{
    public class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly IBucket _bucket;
        private readonly IMapper _mapper;

        public SimpleMessageRepository(ITestBucketProvider testBucketProvider, IMapper mapper)
        {
            _bucket = testBucketProvider != null ? testBucketProvider.GetBucket() : throw new ArgumentNullException(nameof(testBucketProvider));
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> AddMessage(SimpleMessageCreateRequest simpleMessageCreate)
        {
            var dbMessage = _mapper.Map<SimpleMessageDbModel>(simpleMessageCreate);
            var couchbaseKey = GetCouchbaseKey(dbMessage.Id);

            await _bucket.InsertAsync(couchbaseKey, dbMessage);
            var savedDocument = await GetMessage(couchbaseKey);

            return _mapper.Map<SimpleMessage>(savedDocument);
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> RetrieveMessage(Guid id)
        {
            var document = await GetMessage(GetCouchbaseKey(id));

            if (document == null)
            {
                return null;
            }

            return _mapper.Map<SimpleMessage>(document);
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> UpdateMessage(Guid id, SimpleMessageUpdateRequest simpleMessageUpdate)
        {
            var couchbaseKey = GetCouchbaseKey(id);
            var existingDocument = await GetMessage(couchbaseKey);

            if (existingDocument == null || !existingDocument.Enabled)
            {
                return null;
            }

            var dbMessage = _mapper.Map<SimpleMessageUpdateRequest, SimpleMessageDbModel>(simpleMessageUpdate, existingDocument);

            await _bucket.ReplaceAsync(couchbaseKey, dbMessage);

            return await RetrieveMessage(id);
        }

        /// <inheritdoc />
        public async Task DisableMessage(Guid id)
        {
            var couchbaseKey = GetCouchbaseKey(id);
            var message = await GetMessage(couchbaseKey);
            message.Enabled = false;

            _bucket.Replace(couchbaseKey, message);
        }

        private async Task<SimpleMessageDbModel> GetMessage(string couchbaseKey)
        {
            var result = await _bucket.GetAsync<SimpleMessageDbModel>(couchbaseKey);
            return result.Value;
        }

        private string GetCouchbaseKey(Guid id)
        {
            return $"SimpleMessage.{id}";
        }
    }
}
