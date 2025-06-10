using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Common;
using tg.domain.Dtos;

namespace tg.application.Features.User.Login
{
    public sealed record class LoginUserResponse
    {
        required public Result<UserSuccess, UserFailure> Result { get; set; }
    }
}