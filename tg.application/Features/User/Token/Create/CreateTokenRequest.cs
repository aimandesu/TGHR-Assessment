using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using tg.domain.Entities;

namespace tg.application.Features.User.Token.Create
{
    public sealed record CreateTokenRequest(UserModel User) : IRequest<CreateTokenResponse>;
}