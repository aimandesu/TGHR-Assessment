using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository;
using tg.application.Repository.ISkillRepository;
using tg.domain.Entities;

namespace tg.application.Features.Skill.Create
{
    public sealed class CreateSkillHandler : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public CreateSkillHandler(
            IUnitOfWork unitOfWork,
            ISkillRepository skillRepository,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<CreateSkillResponse> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<SkillModel>(request); //this is what config uses for createskillmapper
            _skillRepository.Create(skill);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateSkillResponse>(skill);
        }
    }
}