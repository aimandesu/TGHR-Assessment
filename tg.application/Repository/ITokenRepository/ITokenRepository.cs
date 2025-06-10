using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Entities;

namespace tg.application.Repository.ITokenRepository
{
    public interface ITokenRepository
    {
        string CreateToken(string email, string username, string userId);
    }
}