using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
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
