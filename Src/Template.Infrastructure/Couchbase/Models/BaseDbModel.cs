using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Infrastructure.Couchbase.Models
{
    public class BaseDbModel
    {
        public BaseDbModel()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public DateTime CreatedOn { get; set; }
    }
}
