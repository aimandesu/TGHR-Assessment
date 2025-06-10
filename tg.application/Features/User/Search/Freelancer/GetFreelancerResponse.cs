using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Search.Freelancer
{
    public sealed record GetFreelancerResponse
    {
        public UserModelDto? Freelancer { get; set; }

    }
}