using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Enum;

namespace tg.application.Features.Skill.Create
{
    //this is dto somehow
    public sealed record class CreateSkillResponse
    {
        public string SkillName { get; set; } = string.Empty;
        public Proficiency ProficiencyLevel { get; set; } = Proficiency.Beginner;
    }
}