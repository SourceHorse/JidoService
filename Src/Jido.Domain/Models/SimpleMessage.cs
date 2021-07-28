using System;

namespace Jido.Domain.Models
{
    /// <summary>
    /// A simple message
    /// </summary>
    public class SimpleMessage : BaseModel
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
