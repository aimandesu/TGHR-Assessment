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

namespace tg.application.Features.User.Update
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UpdateUserHandler(
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


        public async Task<UpdateUserResponse> Handle(
            UpdateUserRequest request,
            CancellationToken cancellationToken
        )
        {

            if (!_userService.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated");

            var currentUserId = _userService.UserId;


            // var userModel = _mapper.Map<UserModel>(request.User);

            var userModel = await _userRepository.GetUserById(currentUserId ?? "");

            userModel?.UpdateEmail(request.User.Email);
            userModel?.UpdateUserName(request.User.Username);
            userModel?.UpdatePhoneNumber(request.User.PhoneNumber);

            var user = _userRepository.UpdateUser(userModel);

            await _unitOfWork.Save(cancellationToken);

            // var dto = _mapper.Map<UserModelDto>(user);

            // return _mapper.Map<UpdateUserResponse>(dto);

            return new UpdateUserResponse
            {
                User = _mapper.Map<UserModelDto>(user)
            };


        }
    }
}