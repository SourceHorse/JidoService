using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Services;
using Template.Domain.Services.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ISimpleMessageService, SimpleMessageService>();

            return services;
        }
    }
}
