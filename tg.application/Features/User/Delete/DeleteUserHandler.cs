using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Dtos;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;

namespace tg.application.Features.User.Delete
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(
            DeleteUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var userModel = await _userRepository.DeleteUser(
                request.Email,
                request.Password,
                request.PasswordConfirmation
            );

            await _unitOfWork.Save(cancellationToken);

            //both ni only perlu if we nak usermodel to dto then dto ni to response, see mapper

            // var userModelDto = _mapper.Map<UserModelDto>(userModel);

            return _mapper.Map<DeleteUserResponse>(userModel); // mcm xlogic sbb before i return trus

        }
    }
}