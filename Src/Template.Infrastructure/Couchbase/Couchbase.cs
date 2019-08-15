using System;
using Couchbase.Core;

namespace Template.Infrastructure.Couchbase
{
    class Couchbase : ICouchbase
    {
        private readonly IBucket _bucket;

        public Couchbase(ITestBucketProvider testBucketProvider)
        {
            _bucket = testBucketProvider.GetBucket();
        }

        public void AddTestValue()
        {
            var ticksString = DateTime.Now.Ticks.ToString();
            _bucket.Upsert(ticksString, new {ticks = ticksString});
        }
    }
}
