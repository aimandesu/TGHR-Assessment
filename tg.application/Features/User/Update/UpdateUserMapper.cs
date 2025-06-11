using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Update
{
    public sealed class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<UserModel, UserModelDto>();
            CreateMap<UpdateUserDto, UserModelDto>();
            CreateMap<UserModelDto, UpdateUserResponse>();
        }
    }
}