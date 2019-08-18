using System;
using Template.Domain.Models;

namespace Template.Domain.Couchbase
{
    public interface ISimpleMessageRepository
    {
        /// <summary>
        /// Adds a simple message
        /// </summary>
        /// <param name="simpleMessageCreate">The new message</param>
        SimpleMessage AddMessage(SimpleMessageCreateRequest simpleMessageCreate);

        /// <summary>
        /// Retrieves a simple message
        /// </summary>
        /// <param name="id">The message id</param>
        SimpleMessage RetrieveMessage(Guid id);

        /// <summary>
        /// Updates a simple message
        /// </summary>
        /// <param name="id">The message id</param>
        /// <param name="simpleMessageUpdate">The update message</param>
        SimpleMessage UpdateMessage(Guid id, SimpleMessageUpdateRequest simpleMessageUpdate);

        /// <summary>
        /// Disables a message for soft delete
        /// </summary>
        /// <param name="id"></param>
        void DisableMessage(Guid id);
    }
}
