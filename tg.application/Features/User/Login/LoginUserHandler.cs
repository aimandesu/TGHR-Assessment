using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.User.SignUp;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.User.Login
{
    public sealed class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public async Task<LoginUserResponse> Handle(
            LoginUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await _userRepository.LoginUser(request.Username, request.Password);
            await _unitOfWork.Save(cancellationToken);

            if (!result.IsSuccess)
            {
                return new LoginUserResponse
                {
                    ResultResponse = ResultResponse<UserSuccess, UserFailure>.Fail(result.FailureData!)
                };
            }

            var dto = _mapper.Map<UserModelDto>(result.SuccessData!);

            var successDto = new UserSuccess
            {
                ResultMessage = "User succeed login",
                UserModel = dto
            };

            return new LoginUserResponse
            {
                ResultResponse = ResultResponse<UserSuccess, UserFailure>.Success(successDto)
            };
        }
    }
}