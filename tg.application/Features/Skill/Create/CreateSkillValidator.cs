using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace tg.application.Features.Skill.Create
{
    public sealed class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty();
            RuleFor(x => x.ProficiencyLevel).NotEmpty();
        }
        
    }
}