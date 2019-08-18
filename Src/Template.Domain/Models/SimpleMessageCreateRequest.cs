using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    /// <summary>
    /// For creating a new simple message
    /// </summary>
    class SimpleMessageCreateRequest
    {
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
