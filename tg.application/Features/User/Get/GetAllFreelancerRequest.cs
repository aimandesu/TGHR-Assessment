using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using tg.application.Common;

namespace tg.application.Features.User.Get
{
    public sealed record class GetAllFreelancerRequest(
        PaginationQueryObject PaginationQueryObject
    ) : IRequest<List<GetAllFreelancerResponse>>;
}