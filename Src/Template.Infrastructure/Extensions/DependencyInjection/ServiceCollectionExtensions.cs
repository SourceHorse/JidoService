using Microsoft.Extensions.DependencyInjection;
using Template.Infrastructure.Couchbase;

namespace Template.Infrastructure.Extensions.DependencyInjection

{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ICouchbase, Template.Infrastructure.Couchbase.Couchbase>();

            return services;
        }
    }
}
