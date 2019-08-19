using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Template.Domain.Models;

namespace Template.Api.Validators
{
    public class SimpleMessageUpdateRequestValidator : AbstractValidator<SimpleMessageUpdateRequest>
    {
        public SimpleMessageUpdateRequestValidator()
        {
            RuleFor(msg => msg.Title).NotNull().NotEmpty();
            RuleFor(msg => msg.Title).NotNull().NotEmpty();
        }
    }
}
