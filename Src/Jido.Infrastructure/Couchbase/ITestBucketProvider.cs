using Couchbase.Extensions.DependencyInjection;

namespace Jido.Infrastructure.Couchbase
{
    // from https://blog.couchbase.com/dependency-injection-aspnet-couchbase/
    public interface ITestBucketProvider : INamedBucketProvider {}
}
