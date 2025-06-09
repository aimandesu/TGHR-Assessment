using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.User.SignUp
{
    public sealed class SignUpUserHandler : IRequestHandler<SignUpUserRequest, SignUpUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SignUpUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SignUpUserResponse> Handle(SignUpUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserModel>(request);
            var result = await _userRepository.SignUp(user, request.Password);
            await _unitOfWork.Save(cancellationToken);

            return new SignUpUserResponse { Result = result };
        }

    }
}