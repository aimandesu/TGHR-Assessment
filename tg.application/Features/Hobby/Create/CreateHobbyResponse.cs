using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Features.Hobby.Create
{
    public sealed record class CreateHobbyResponse
    {
        public string UserId { get; set; } = string.Empty;
        public string HobbyName { get; set; } = string.Empty;
    }
}