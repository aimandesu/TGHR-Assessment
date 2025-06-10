using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Repository.ITokenRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Dtos;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;


        public UserRepository(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            ApplicationDbContext context,
            ILogger<UserRepository> logger
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;

        }

        public Task LoginUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModelDto?> SearchFreelancer(string email, string username)
        {
            _logger.LogInformation(username);
            _logger.LogInformation(email);
            UserModel? user = await _context.Users.FirstOrDefaultAsync(e => e.Email == email && e.UserName == username);
            var dto = new UserModelDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName
            };

            return dto;

        }

        public async Task<Result<UserSuccess, UserFailure>> SignUp(UserModel user, string password)
        {
            var createdUser = await _userManager.CreateAsync(user, password);

            if (!createdUser.Succeeded)
            {
                var failDto = new UserFailure
                {
                    ResultMessage = createdUser.ToString()
                };

                return Result<UserSuccess, UserFailure>.Fail(failDto);
            }

            var dto = new UserModelDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName
            };


            var successDto = new UserSuccess
            {
                ResultMessage = "Creating user successful",
                UserModel = dto
            };

            return Result<UserSuccess, UserFailure>.Success(successDto);

        }
    }
}