using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.Skill.Get
{
    public sealed class GetSkillMapper : Profile
    {
        public GetSkillMapper()
        {
            CreateMap<SkillModel, GetSkillResponse>();
        }
    }
}