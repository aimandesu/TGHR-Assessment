using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tg.domain.Enum;

namespace tg.domain.Entities
{

    public class SkillModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public Proficiency Proficiency { get; set; } = Proficiency.Beginner;
        public string UserId { get; set; } = string.Empty;

        public UserModel? User { get; set; }

    }
}