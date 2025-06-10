using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository.IUserRepository;
using tg.application.Dtos;

namespace tg.application.Features.User.Search.Freelancer
{
    public sealed class GetFreelancerHandler : IRequestHandler<GetFreelancerRequest, GetFreelancerResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetFreelancerHandler(
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetFreelancerResponse> Handle(
            GetFreelancerRequest request,
            CancellationToken cancellationToken
        )
        {
            var userModel = await _userRepository.SearchFreelancer(request.Email, request.Username);

            var dto = _mapper.Map<UserModelDto>(userModel);

            return new GetFreelancerResponse
            {
                Freelancer = dto
            };
        }
    }
}