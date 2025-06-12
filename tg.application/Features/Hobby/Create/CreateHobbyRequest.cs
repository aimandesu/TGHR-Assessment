using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace tg.application.Features.Hobby.Create
{
    public sealed record class CreateHobbyRequest(
        string HobbyName
    ) : IRequest<CreateHobbyResponse>;
}