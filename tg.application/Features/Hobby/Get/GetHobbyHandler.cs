using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository.IHobbyRepository;
using tg.application.Repository.IUserRepository;

namespace tg.application.Features.Hobby.Get
{
    public class GetHobbyHandler : IRequestHandler<GetHobbyRequest, List<GetHobbyResponse>>
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetHobbyHandler(
             IHobbyRepository hobbyRepository,
            IMapper mapper,
            IUserService userService
        )
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<GetHobbyResponse>> Handle(
            GetHobbyRequest request,
            CancellationToken cancellationToken
        )
        {

            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            var userId = _userService.UserId;

            var hobbies = await _hobbyRepository.GetHobbies(userId ?? "");

            return _mapper.Map<List<GetHobbyResponse>>(hobbies);

        }
    }
}