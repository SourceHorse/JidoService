using System;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.Couchbase
{
    public interface ISimpleMessageRepository
    {
        /// <summary>
        /// Adds a simple message
        /// </summary>
        /// <param name="simpleMessageCreate">The new message</param>
        Task<SimpleMessage> AddMessage(SimpleMessageCreateRequest simpleMessageCreate);

        /// <summary>
        /// Retrieves a simple message
        /// </summary>
        /// <param name="id">The message id</param>
        Task<SimpleMessage> RetrieveMessage(Guid id);

        /// <summary>
        /// Updates a simple message
        /// </summary>
        /// <param name="id">The message id</param>
        /// <param name="simpleMessageUpdate">The update message</param>
        Task<SimpleMessage> UpdateMessage(Guid id, SimpleMessageUpdateRequest simpleMessageUpdate);

        /// <summary>
        /// Disables a message for soft delete
        /// </summary>
        /// <param name="id"></param>
        Task DisableMessage(Guid id);
    }
}
