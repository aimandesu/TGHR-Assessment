using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository.ISkillRepository;

namespace tg.application.Features.Skill.Get
{
    public sealed class GetSkillHandler : IRequestHandler<GetSkillRequest, List<GetSkillResponse>>
    {

        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillHandler(

            ISkillRepository skillRepository,
            IMapper mapper
        )
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }


        public async Task<List<GetSkillResponse>> Handle(GetSkillRequest request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetSkills();

            return _mapper.Map<List<GetSkillResponse>>(skills);
        }
    }
}