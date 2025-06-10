using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.domain.Dtos
{
    public class UserModelDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

    }
}