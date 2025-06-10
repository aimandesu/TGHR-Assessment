using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User
{
    public class UserSuccess
    {
        public string ResultMessage { get; set; } = string.Empty;
        public UserModelDto? UserModel { get; set; }
    }
}