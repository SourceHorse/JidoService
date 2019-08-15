using Template.Domain.Models;

namespace Template.Domain.Couchbase
{
    public interface ISimpleMessageRepository
    {
        /// <summary>
        /// Adds a simple message
        /// </summary>
        /// <param name="simpleMessage">The message</param>
        SimpleMessage AddMessage(SimpleMessage simpleMessage);
    }
}
