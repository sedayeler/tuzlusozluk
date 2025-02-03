using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Services;
using TuzluSozluk.Common.Models.RequestModels;
using TuzluSozluk.Common.Models.ResponseModels;

namespace TuzluSozluk.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            string token = await _userService.LoginAsync(request.Email, request.Password);

            return new()
            {
                Token = token
            };
        }
    }
}
