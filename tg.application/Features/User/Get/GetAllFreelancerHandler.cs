using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository.IUserRepository;

namespace tg.application.Features.User.Get
{
    public sealed class GetAllFreelancerHandler : IRequestHandler<GetAllFreelancerRequest, List<GetAllFreelancerResponse>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllFreelancerHandler(
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllFreelancerResponse>> Handle(
            GetAllFreelancerRequest request,
            CancellationToken cancellationToken
        )
        {

            var freelancers = await _userRepository.SearchAllFreelancer();

            return _mapper.Map<List<GetAllFreelancerResponse>>(freelancers);

        }
    }
}