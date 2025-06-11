using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace tg.domain.Entities
{
    public class UserModel : IdentityUser
    {
        // public string Username { get; set; } = string.Empty;
        // public string Email { get; set; } = string.Empty;
        // public string PhoneNumber { get; set; } = string.Empty;

        //everything commented out is part of IdentityUsers, so dont even need to write, but you can specificy override technically

        public List<SkillModel> Skills { get; set; } = [];
        public List<HobbyModel> Hobbies { get; set; } = [];
    }
}