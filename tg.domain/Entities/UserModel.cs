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

        public bool IsArchived { get; set; } = false;

        public List<SkillModel> Skills { get; set; } = [];
        public List<HobbyModel> Hobbies { get; set; } = [];

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format");

            Email = email;
        }

        public void UpdateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Username cannot be empty");

            UserName = userName;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}