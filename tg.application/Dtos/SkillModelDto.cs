using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Enum;

namespace tg.application.Dtos
{
    public class SkillModelDto
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public Proficiency ProficiencyLevel { get; set; }
    }
}