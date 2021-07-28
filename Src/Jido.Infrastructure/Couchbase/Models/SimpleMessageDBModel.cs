using System;
using Jido.Domain.Models;

namespace Jido.Infrastructure.Couchbase.Models
{
    /// <summary>
    /// A simple message db model
    /// </summary>
    public class SimpleMessageDbModel : BaseModel
    {
        /// <summary>
        /// The message id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The message title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The message body
        /// </summary>
        public string Body { get; set; }
    }
}
