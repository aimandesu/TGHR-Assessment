using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Archive
{
    public class ArchiveUnarchiveFreelancerMapper : Profile
    {
        public ArchiveUnarchiveFreelancerMapper()
        {
            CreateMap<UserModel, UserModelDto>();
        }
    }
}