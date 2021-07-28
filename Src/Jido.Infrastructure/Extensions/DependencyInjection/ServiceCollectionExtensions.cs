using Jido.Domain.Couchbase;
using Jido.Infrastructure;
using Jido.Infrastructure.Couchbase;
using AutoMapper;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ISimpleMessageRepository, SimpleMessageRepository>();
            services.AddTransient(provider => 
                new MapperConfiguration( cfg =>
                    {
                        cfg.AddProfile(new AutoMapperProfile());
                    }).CreateMapper());

            return services;
        }
    }
}
