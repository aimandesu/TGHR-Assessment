using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace tg.application.Features.User.Search
{
    public sealed class GetFreelancerValidator : AbstractValidator<GetFreelancerRequest>
    {
        public GetFreelancerValidator()
        {
            // RuleFor(x => x)
            //     .Must(x => !string.IsNullOrWhiteSpace(x.Username) || !string.IsNullOrWhiteSpace(x.Email))
            //     .WithMessage("Either Username or Email must be provided.");
        }
    }
}