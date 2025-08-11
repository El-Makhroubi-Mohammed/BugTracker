using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password 
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
