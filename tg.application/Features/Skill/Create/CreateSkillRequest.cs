using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Enum;
using MediatR;

namespace tg.application.Features.Skill.Create
{
    public sealed record CreateSkillRequest(string SkillName, Proficiency ProficiencyLevel) : IRequest<CreateSkillResponse>;
}