using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Couchbase;
using Template.Infrastructure;
using Template.Infrastructure.Couchbase;
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
