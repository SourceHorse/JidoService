using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Template.Api.Validators;
using Template.Domain.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SimpleMessageCreateRequest>, SimpleMessageCreateRequestValidator>();
            services.AddTransient<IValidator<SimpleMessageUpdateRequest>, SimpleMessageUpdateRequestValidator>();

            return services;
        }
    }
}
