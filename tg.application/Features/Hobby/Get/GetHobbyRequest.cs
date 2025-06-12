using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.Hobby.Get
{
    public sealed record class GetHobbyRequest : IRequest<List<GetHobbyResponse>>;
}