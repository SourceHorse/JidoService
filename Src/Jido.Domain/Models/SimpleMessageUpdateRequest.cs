namespace Jido.Domain.Models
{
    /// <summary>
    /// For updating an existing simple message
    /// </summary>
    public class SimpleMessageUpdateRequest
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
