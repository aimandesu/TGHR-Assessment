using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Update
{
    public sealed record class UpdateUserRequest(
        UpdateUserDto User
    ) : IRequest<UpdateUserResponse>;

}