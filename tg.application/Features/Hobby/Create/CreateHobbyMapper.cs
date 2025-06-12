using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.Hobby.Create
{
    public class CreateHobbyMapper : Profile
    {
        public CreateHobbyMapper()
        {
            CreateMap<HobbyModel, CreateHobbyResponse>();
        }
    }
}