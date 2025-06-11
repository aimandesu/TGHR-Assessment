using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Delete
{
    public sealed class DeleteUserMapper : Profile
    {
        public DeleteUserMapper()
        {
            //both ni only perlu if we nak usermodel to dto then dto ni to response
            // CreateMap<UserModel, UserModelDto>();
            // CreateMap<UserModelDto, DeleteUserResponse>();
            CreateMap<UserModel, DeleteUserResponse>();
        }
    }
}