using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.User.Login
{
    public sealed record LoginUserRequest(string Username, string Password) : IRequest<LoginUserResponse>;
}