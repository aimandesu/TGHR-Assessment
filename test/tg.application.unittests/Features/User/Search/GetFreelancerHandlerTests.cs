using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using tg.application.Dtos;
using tg.application.Features.User.Search;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;
using Xunit;

namespace tg.application.unittests.Features.User.Search
{
    public class GetFreelancerHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetFreelancerHandler _handler;

        public GetFreelancerHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetFreelancerHandler(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedDto_WhenValidEmailOrUsernameProvided()
        {
            // Arrange
            var request = new GetFreelancerRequest("john@example.com", "john");


            var userModel = new UserModel
            {
                Id = "1",
                Email = "john@example.com",
                UserName = "john"
            };

            var userDto = new UserModelDto
            {
                Id = "1",
                Email = "john@example.com",
                Username = "john"
            };

            _userRepositoryMock
                .Setup(r => r.SearchFreelancer(
                    request.Email,
                    request.Username
                    )
                )
                .ReturnsAsync(userModel);

            _mapperMock
                .Setup(m => m.Map<UserModelDto>(userModel))
                .Returns(userDto);

            // Act
            var result = await _handler.Handle(
                request,
                CancellationToken.None
            );

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Freelancer);
            Assert.Equal(userDto.Email, result.Freelancer.Email);
            Assert.Equal(userDto.Username, result.Freelancer.Username);

            _userRepositoryMock.Verify(r => r.SearchFreelancer(
                request.Email, request.Username),
                Times.Once
            );

            _mapperMock.Verify(m => m.Map<UserModelDto>(userModel), Times.Once);
        }
    }
}
