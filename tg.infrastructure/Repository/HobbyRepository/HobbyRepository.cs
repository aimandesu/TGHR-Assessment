using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tg.application.Repository.IHobbyRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.HobbyRepository
{
    public class HobbyRepository : IHobbyRepository
    {

        private readonly ApplicationDbContext _context;

        public HobbyRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task Create(HobbyModel hobbyModel)
        {
            await _context.Hobbies.AddAsync(hobbyModel);
        }

        public async Task<List<HobbyModel>> GetHobbies(string userId)
        {
            return await _context.Hobbies
                .Where((e) => e.UserId == userId)
                .ToListAsync();
        }
    }
}