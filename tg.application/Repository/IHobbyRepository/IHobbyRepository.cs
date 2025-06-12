using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Entities;

namespace tg.application.Repository.IHobbyRepository
{
    public interface IHobbyRepository
    {
        Task Create(HobbyModel hobbyModel);
        Task<List<HobbyModel>> GetHobbies(string userId);
    }
}