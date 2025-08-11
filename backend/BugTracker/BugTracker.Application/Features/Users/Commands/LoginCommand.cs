using BugTracker.Application.Dtos.Users;
using BugTracker.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Users.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<LoginResponse>;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(new LoginRequest
            {
                Username = request.Username,
                Password = request.Password
            });
        }
    }

}
