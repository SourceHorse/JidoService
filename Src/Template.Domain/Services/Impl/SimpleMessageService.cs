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
        public SimpleMessage AddMessage(SimpleMessage simpleMessage)
        {
            return _simpleMessageRepository.AddMessage(simpleMessage);
        }

        public SimpleMessage RetrieveMessage(Guid id)
        {
            return _simpleMessageRepository.RetrieveMessage(id);
        }

        public SimpleMessage UpdateMessage(Guid id, SimpleMessage simpleMessage)
        {
            return _simpleMessageRepository.UpdateMessage(id, simpleMessage);
        }
    }
}
