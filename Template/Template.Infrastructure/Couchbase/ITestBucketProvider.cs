using Couchbase.Extensions.DependencyInjection;

namespace Template.Infrastructure.Couchbase
{
    // from https://blog.couchbase.com/dependency-injection-aspnet-couchbase/
    public interface ITestBucketProvider : INamedBucketProvider {}
}
