using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.User.SignUp
{
    public sealed record SignUpUserRequest(string Email, string Username, string Password) : IRequest<SignUpUserResponse>;
}