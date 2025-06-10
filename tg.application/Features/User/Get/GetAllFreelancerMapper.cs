using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.domain.Entities;

namespace tg.application.Features.User.Get
{
    public sealed class GetAllFreelancerMapper : Profile
    {
        public GetAllFreelancerMapper()
        {
            // CreateMap<GetAllFreelancerRequest, UserModel>();
            CreateMap<UserModel, GetAllFreelancerResponse>();
        }
    }
}