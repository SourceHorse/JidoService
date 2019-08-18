using System;
using Template.Domain.Couchbase;
using Template.Domain.Models;

namespace Template.Domain.Services.Impl
{
    public class SimpleMessageService : ISimpleMessageService
    {
        private readonly ISimpleMessageRepository _simpleMessageRepository;

        public SimpleMessageService(ISimpleMessageRepository simpleMessageRepository)
        {
            _simpleMessageRepository = simpleMessageRepository ?? throw new ArgumentNullException(nameof(simpleMessageRepository));
        }

        /// <inheritdoc />
        public SimpleMessage AddMessage(SimpleMessageCreateRequest simpleMessageCreate)
        {
            return _simpleMessageRepository.AddMessage(simpleMessageCreate);
        }

        /// <inheritdoc />
        public SimpleMessage RetrieveMessage(Guid id)
        {
            return _simpleMessageRepository.RetrieveMessage(id);
        }

        /// <inheritdoc />
        public SimpleMessage UpdateMessage(Guid id, SimpleMessageUpdateRequest simpleMessageUpdate)
        {
            return _simpleMessageRepository.UpdateMessage(id, simpleMessageUpdate);
        }

        /// <inheritdoc />
        public void DeleteMessage(Guid id)
        {
            _simpleMessageRepository.DisableMessage(id);
        }
    }
}
