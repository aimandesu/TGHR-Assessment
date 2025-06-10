using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Entities;

namespace tg.application.Dtos
{
    public class UserModelDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public List<SkillModelDto> Skills { get; set; } = [];
    }
}