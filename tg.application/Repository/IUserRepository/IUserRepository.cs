using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Common;
using tg.application.Features.User;
using tg.domain.Dtos;
using tg.domain.Entities;

namespace tg.application.Repository.IUserRepository
{
    public interface IUserRepository
    {
        Task<Result<UserSuccess, UserFailure>> SignUp(UserModel user, string password);
        Task<Result<UserSuccess, UserFailure>> LoginUser(string username, string password);

        Task<UserModelDto?> SearchFreelancer(string email, string username);

    }
}