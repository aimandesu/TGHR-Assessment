using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Entities;

namespace tg.application.Repository.ISkillRepository
{
    public interface ISkillRepository
    {
        void Create(SkillModel skill);
        Task<List<SkillModel>> GetSkills();
    }
}