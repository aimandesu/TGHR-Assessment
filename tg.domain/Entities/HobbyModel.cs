using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tg.domain.Entities
{
    public class HobbyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string HobbyName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public UserModel? User { get; set; }
    }
}