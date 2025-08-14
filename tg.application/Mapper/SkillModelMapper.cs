using tg.application.Dtos;
using tg.domain.Entities;
using tg.domain.Enum;

namespace tg.application.Mapper;

public static class SkillModelMapper
{
    public static SkillModelDto ToSkillModelDto(this SkillModel skillModel)
    {
        return new SkillModelDto
        {
            Id = skillModel.Id,
            SkillName = skillModel.SkillName,
            ProficiencyLevel = skillModel.ProficiencyLevel,
        };
    }
}