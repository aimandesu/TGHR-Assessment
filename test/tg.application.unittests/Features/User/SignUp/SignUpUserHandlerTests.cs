using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.User;
using tg.application.Features.User.SignUp;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;
using Xunit;

namespace tg.application.unittests.Features.User.SignUp
{
    public class SignUpUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly SignUpUserHandler _handler;

        public SignUpUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new SignUpUserHandler(
                _unitOfWorkMock.Object,
                _userRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedDto_WhenUserSignUpSuccess()
        {

            // Given
            var request = new SignUpUserRequest("john@example.com", "john", "john18012001_");

            var user = new UserModel
            {
                Id = "1",
                Email = "john@example.com",
                UserName = "john"
            };

            var userDto = new UserModelDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName
            };

            var successResult = ResultResponse<UserModel, UserFailure>.Success(user);

            _mapperMock.Setup(m => m.Map<UserModel>(request))
                .Returns(user);

            _userRepositoryMock.Setup(r => r.SignUp(user, request.Password))
                .ReturnsAsync(successResult);

            _unitOfWorkMock.Setup(u => u.Save(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<UserModelDto>(user))
                .Returns(userDto);


            // When
            var response = await _handler.Handle(request, CancellationToken.None);


            // Then
            Assert.True(response.ResultResponse.IsSuccess);
            Assert.NotNull(response.ResultResponse.SuccessData);
            Assert.Equal("User Created Account", response.ResultResponse.SuccessData!.ResultMessage);
            Assert.Equal(userDto.Email, response.ResultResponse?.SuccessData?.UserModel?.Email);

            // Verify interactions
            _userRepositoryMock.Verify(r => r.SignUp(user, request.Password), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(It.IsAny<CancellationToken>()), Times.Once);
            _mapperMock.Verify(m => m.Map<UserModel>(request), Times.Once);
            _mapperMock.Verify(m => m.Map<UserModelDto>(user), Times.Once);
        }

    }

}