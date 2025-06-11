using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Features.User.Delete
{
    public sealed record DeleteUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}