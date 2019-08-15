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
        public void AddMessage(SimpleMessage simpleMessage)
        {
            _simpleMessageRepository.AddMessage(simpleMessage);
        }
    }
}
