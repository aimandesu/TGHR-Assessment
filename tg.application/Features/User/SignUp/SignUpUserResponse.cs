using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Common;

namespace tg.application.Features.User.SignUp
{
    public sealed record class SignUpUserResponse
    {
        required public Result<UserSuccess, UserFailure> Result { get; set; }
    }
}