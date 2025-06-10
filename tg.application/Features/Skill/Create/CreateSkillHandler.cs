using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository;
using tg.application.Repository.ISkillRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Skill.Create
{
    public sealed class CreateSkillHandler : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateSkillHandler(
            IUnitOfWork unitOfWork,
            ISkillRepository skillRepository,
            IMapper mapper,
            IUserService userService
        )
        {
            _unitOfWork = unitOfWork;
            _skillRepository = skillRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreateSkillResponse> Handle(
            CreateSkillRequest request,
            CancellationToken cancellationToken
        )
        {

            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            var skill = new SkillModel
            {
                SkillName = request.SkillName,
                ProficiencyLevel = request.ProficiencyLevel,
                UserId = _userService.UserId!
            };

            skill = _mapper.Map<SkillModel>(skill); //this is what config uses for createskillmapper, we can also use request directly
            await _skillRepository.Create(skill);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateSkillResponse>(skill);
        }
    }
}