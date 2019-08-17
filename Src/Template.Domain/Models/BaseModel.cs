using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedOn = DateTime.UtcNow;
            Enabled = true;
        }

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
