using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.User.Get
{
    public sealed record class GetAllFreelancerRequest() : IRequest<List<GetAllFreelancerResponse>>;
}