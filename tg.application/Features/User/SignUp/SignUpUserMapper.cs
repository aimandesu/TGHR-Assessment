using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.SignUp
{
    public sealed class SignUpUserMapper : Profile
    {
        public SignUpUserMapper()
        {
            CreateMap<SignUpUserRequest, UserModel>();
            // CreateMap<UserModel, SignUpUserResponse>(); //SignUpUserDto
            // CreateMap<UserModelDto, SignUpUserResponse>();
            CreateMap<UserModel, UserModelDto>();
            CreateMap<SkillModel, SkillModelDto>();
        }
    }
}