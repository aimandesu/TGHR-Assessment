using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.Skill.Get
{
    public sealed record class GetSkillRequest : IRequest<List<GetSkillResponse>>;
}