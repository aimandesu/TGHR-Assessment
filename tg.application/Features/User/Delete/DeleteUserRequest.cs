using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.User.Delete
{
    public sealed record class DeleteUserRequest(
        string Email,
        string Password,
        string PasswordConfirmation
    ) : IRequest<DeleteUserResponse>;
}