using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Repository.IUserRepository
{
    public interface IUserRepository
    {
        Task<Result<UserModel, UserFailure>> SignUp(UserModel user, string password);
        Task<Result<UserModel, UserFailure>> LoginUser(string username, string password);
        Task<UserModel?> SearchFreelancer(string email, string username);
        Task<List<UserModel>> SearchAllFreelancer();

    }
}