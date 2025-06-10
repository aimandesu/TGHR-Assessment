using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Get
{
    public sealed record GetAllFreelancerResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}