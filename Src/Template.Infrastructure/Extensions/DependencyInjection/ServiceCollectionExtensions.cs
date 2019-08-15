using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Couchbase;
using Template.Infrastructure.Couchbase;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ISimpleMessageRepository, SimpleMessageRepository>();

            return services;
        }
    }
}
