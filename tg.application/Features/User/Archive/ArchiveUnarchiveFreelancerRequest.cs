using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.User.Archive
{
    public sealed record class ArchiveUnarchiveFreelancerRequest(bool IsArchived) : IRequest<UserModelDto>;
}