using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.domain.Entities
{
    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public List<SkillModel> Skills { get; set; } = [];
        public List<HobbyModel> Hobbies { get; set; } = [];
    }
}