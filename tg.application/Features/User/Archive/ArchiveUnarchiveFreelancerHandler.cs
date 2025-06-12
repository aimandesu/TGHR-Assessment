using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Dtos;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.User.Archive
{
    public class ArchiveUnarchiveFreelancerHandler : IRequestHandler<ArchiveUnarchiveFreelancerRequest, UserModelDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ArchiveUnarchiveFreelancerHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper,
              IUserService userService
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserModelDto> Handle(
            ArchiveUnarchiveFreelancerRequest request,
            CancellationToken cancellationToken
        )
        {
            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            var userId = _userService.UserId;

            var user = await _userRepository.GetUserById(userId);
            user.IsArchived = request.IsArchived;
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<UserModelDto>(user);


        }


    }
}