using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Dtos
{
    public sealed record class UpdateUserDto(
        string Email,
        string Username,
        string PhoneNumber
    // List<SkillModelDto> Skills
    );

}