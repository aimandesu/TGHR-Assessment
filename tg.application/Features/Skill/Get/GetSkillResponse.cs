using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Enum;

namespace tg.application.Features.Skill.Get
{
    public sealed record GetSkillResponse
    {
        public string SkillName { get; set; } = string.Empty;
        public Proficiency ProficiencyLevel { get; set; } = Proficiency.Beginner;
    }
}