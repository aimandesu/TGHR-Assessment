using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Features.User.Token.Create
{
    public sealed record class CreateTokenResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}