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
        private readonly IUserService _userService;

        public DeleteUserHandler(
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

        public async Task<DeleteUserResponse> Handle(
            DeleteUserRequest request,
            CancellationToken cancellationToken
        )
        {
            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            if (request.Email != _userService.Email)
            {
                throw new UnauthorizedAccessException("User to delete is not the same one that authenticated");
            }

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