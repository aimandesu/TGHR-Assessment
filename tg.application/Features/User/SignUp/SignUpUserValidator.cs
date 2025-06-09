using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace tg.application.Features.User.SignUp
{
    public sealed class SignUpUserValidator : AbstractValidator<SignUpUserRequest>
    {
        public SignUpUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }

    }
}