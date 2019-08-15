using System;

namespace Template.Infrastructure.Couchbase.Models
{
    /// <summary>
    /// A simple message db model
    /// </summary>
    public class SimpleMessageDbModel : BaseDbModel
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
        /// The message
        /// </summary>
        public string Message { get; set; }
    }
}
