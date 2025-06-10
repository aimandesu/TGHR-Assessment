using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository.IUserRepository;

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

        public async Task<GetFreelancerResponse> Handle(GetFreelancerRequest request, CancellationToken cancellationToken)
        {
            var freelancer = await _userRepository.SearchFreelancer(request.Email, request.Username);

            return new GetFreelancerResponse
            {
                Freelancer = freelancer
            };
        }
    }
}