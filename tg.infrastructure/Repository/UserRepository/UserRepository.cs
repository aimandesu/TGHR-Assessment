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

        public async Task<UserModel> DeleteUser(
            string email,
            string password,
            string passwordConfirmation
        )
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            if (password != passwordConfirmation)
            {
                throw new ArgumentException("Password and confirmation do not match");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false
            );

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            await _userManager.DeleteAsync(user);

            return user;

        }

        public async Task<UserModel?> GetUserById(string id)
        {
            return await _context.Users
                .Include(u => u.Skills)
                .Include(u => u.Hobbies)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Result<UserModel, UserFailure>> LoginUser(
            string username,
            string password
        )
        {
            var user = await _userManager.Users.Include(e => e.Skills).FirstOrDefaultAsync(
                x => x.UserName == username
            );

            if (user == null)
            {
                return Result<UserModel, UserFailure>.Fail(new UserFailure
                {
                    ResultMessage = "Username not found"
                });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                return Result<UserModel, UserFailure>.Fail(new UserFailure
                {
                    ResultMessage = "Username not found and/or wrong password"
                });
            }

            return Result<UserModel, UserFailure>.Success(user);
        }

        public async Task<List<UserModel>> SearchAllFreelancer()
        {
            var userModels = await _context.Users.ToListAsync();
            _logger.LogInformation(userModels.ToString());

            return userModels;
        }

        public async Task<UserModel?> SearchFreelancer(string email, string username)
        {

            _logger.LogInformation(username);
            _logger.LogInformation(email);

            UserModel? user = await _context.Users.Include(e => e.Skills).FirstOrDefaultAsync(
                e => e.Email == email &&
                e.UserName == username
            );

            return user;

        }

        public async Task<Result<UserModel, UserFailure>> SignUp(
            UserModel user,
            string password
        )
        {
            var createdUser = await _userManager.CreateAsync(user, password);

            if (!createdUser.Succeeded)
            {

                return Result<UserModel, UserFailure>.Fail(new UserFailure
                {
                    ResultMessage = createdUser.ToString()
                });
            }

            return Result<UserModel, UserFailure>.Success(user);

        }

        public UserModel UpdateUser(UserModel userModel)
        {
            // _logger.LogInformation(userModel.ToString());

            _context.Users.Update(userModel);
            return userModel;
        }

    }
}