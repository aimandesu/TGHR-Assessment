using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Dtos;

namespace tg.application.Features.User.Update
{
    public class UpdateUserResponse
    {
        public UserModelDto? User { get; set; }
    }
}