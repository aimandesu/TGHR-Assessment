using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.Skill.Create
{
    public sealed class CreateSkillMapper : Profile
    {
        public CreateSkillMapper()
        {
            CreateMap<CreateSkillRequest, SkillModel>();
            CreateMap<SkillModel, CreateSkillResponse>();

        }
    }
}