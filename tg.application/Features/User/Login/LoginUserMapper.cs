using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.User.Login
{
    public sealed class LoginUserMapper : Profile
    {
        public LoginUserMapper()
        {
            // CreateMap<LoginUserRequest, UserModel>();
            // CreateMap<UserModel, LoginUserResponse>();
        }
    }
}