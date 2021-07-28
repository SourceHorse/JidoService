using System;
using System.Threading.Tasks;
using Jido.Domain.Couchbase;
using Jido.Domain.Models;

namespace Jido.Domain.Services.Impl
{
    public class SimpleMessageService : ISimpleMessageService
    {
        private readonly ISimpleMessageRepository _simpleMessageRepository;

        public SimpleMessageService(ISimpleMessageRepository simpleMessageRepository)
        {
            _simpleMessageRepository = simpleMessageRepository ?? throw new ArgumentNullException(nameof(simpleMessageRepository));
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> AddMessage(SimpleMessageCreateRequest simpleMessageCreate)
        {
            return await _simpleMessageRepository.AddMessage(simpleMessageCreate);
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> RetrieveMessage(Guid id)
        {
            return await _simpleMessageRepository.RetrieveMessage(id);
        }

        /// <inheritdoc />
        public async Task<SimpleMessage> UpdateMessage(Guid id, SimpleMessageUpdateRequest simpleMessageUpdate)
        {
            return await _simpleMessageRepository.UpdateMessage(id, simpleMessageUpdate);
        }

        /// <inheritdoc />
        public async Task DeleteMessage(Guid id)
        {
            await _simpleMessageRepository.DisableMessage(id);
        }
    }
}
