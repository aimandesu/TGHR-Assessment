using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using tg.application.Repository;
using tg.application.Repository.ITokenRepository;

namespace tg.application.Features.User.Token.Create
{
    public sealed class CreateTokenHandler : IRequestHandler<CreateTokenRequest, CreateTokenResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenRepository _tokenRepository;

        public CreateTokenHandler(
            IUnitOfWork unitOfWork,
            ITokenRepository tokenRepository
        )
        {
            _unitOfWork = unitOfWork;
            _tokenRepository = tokenRepository;
        }

        public async Task<CreateTokenResponse> Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            var token = _tokenRepository.CreateToken(request.User.Email, request.User.UserName, request.User.Id);
            await _unitOfWork.Save(cancellationToken);

            return new CreateTokenResponse { Token = token };
        }
    }

}