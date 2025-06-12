using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository;
using tg.application.Repository.IHobbyRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Hobby.Create
{
    public class CreateHobbyHandler : IRequestHandler<CreateHobbyRequest, CreateHobbyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CreateHobbyHandler(
            IUnitOfWork unitOfWork,
            IHobbyRepository hobbyRepository,
            IMapper mapper,
            IUserService userService
        )
        {
            _unitOfWork = unitOfWork;
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreateHobbyResponse> Handle(
            CreateHobbyRequest request,
            CancellationToken cancellationToken
        )
        {
            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            var hobby = new HobbyModel
            {
                HobbyName = request.HobbyName,
                UserId = _userService.UserId ?? "",
            };

            await _hobbyRepository.Create(hobby);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateHobbyResponse>(hobby);

        }
    }
}