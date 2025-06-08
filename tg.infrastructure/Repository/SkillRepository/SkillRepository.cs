using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tg.application.Repository.ISkillRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.SkillRepository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public void Create(SkillModel skill)
        {
            _context.Skill.Add(skill);
        }

        public async Task<List<SkillModel>> GetSkills()
        {
            return await _context.Skill.ToListAsync();
        }
    }
}