using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.Hobby.Get
{
    public sealed class GetHobbyMapper : Profile
    {
        public GetHobbyMapper()
        {
            CreateMap<HobbyModel, GetHobbyResponse>();
        }
    }
}