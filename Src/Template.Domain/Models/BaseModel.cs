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
        }

        public DateTime CreatedOn { get; set; }
    }
}
