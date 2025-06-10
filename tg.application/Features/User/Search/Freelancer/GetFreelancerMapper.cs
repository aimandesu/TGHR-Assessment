using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.User.Search.Freelancer
{
    public sealed class GetFreelancerMapper : Profile
    {
        public GetFreelancerMapper()
        {
            CreateMap<GetFreelancerRequest, UserModel>();
            CreateMap<UserModel, GetFreelancerResponse>();
        }
    }
}