using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.DTOs;
using TuzluSozluk.Application.Services;

namespace TuzluSozluk.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateUserAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password
            });

            return new()
            {
                UserId = response.Id,
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
