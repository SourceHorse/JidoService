using System;

namespace Jido.Domain.Models
{
    public class BaseModel
    {
        /// <summary>
        /// The message create datetime
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The message enabled status
        /// </summary>
        public bool Enabled { get; set; }
    }
}
