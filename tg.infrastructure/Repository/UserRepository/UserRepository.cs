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
using tg.application.Dtos;
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

        public async Task<Result<UserSuccess, UserFailure>> LoginUser(
            string username,
            string password
        )
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                var failDto = new UserFailure
                {
                    ResultMessage = "Username not found"
                };

                return Result<UserSuccess, UserFailure>.Fail(failDto);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {

                var failDto = new UserFailure
                {
                    ResultMessage = "Username not found and/or wrong password"
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
                ResultMessage = "User succeed login",
                UserModel = dto
            };

            return Result<UserSuccess, UserFailure>.Success(successDto);

        }

        public async Task<UserModel?> SearchFreelancer(string email, string username)
        {

            _logger.LogInformation(username);
            _logger.LogInformation(email);

            UserModel? user = await _context.Users.Include(e => e.Skills).FirstOrDefaultAsync(e => e.Email == email && e.UserName == username);

            return user;

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