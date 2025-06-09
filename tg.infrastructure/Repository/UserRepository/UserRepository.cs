using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Repository.ITokenRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;


        public UserRepository(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager

        )
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public Task LoginUser(UserModel user)
        {
            throw new NotImplementedException();
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

            var successDto = new UserSuccess
            {
                ResultMessage = "Creating user successful"
            };

            return Result<UserSuccess, UserFailure>.Success(successDto);

        }
    }
}