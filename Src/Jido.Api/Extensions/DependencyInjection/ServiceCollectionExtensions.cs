using FluentValidation;
using Jido.Api.Validators;
using Jido.Domain.Models;

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
