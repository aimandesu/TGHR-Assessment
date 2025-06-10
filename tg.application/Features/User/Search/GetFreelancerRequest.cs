using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.User.Search
{
    public sealed record class GetFreelancerRequest(string Email, string Username) : IRequest<GetFreelancerResponse>;
}