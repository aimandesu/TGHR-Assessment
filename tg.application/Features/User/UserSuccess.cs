using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Entities;

namespace tg.application.Features.User
{
    public class UserSuccess
    {
        public string ResultMessage { get; set; } = string.Empty;
        public UserModel? UserModel { get; set; }
    }
}