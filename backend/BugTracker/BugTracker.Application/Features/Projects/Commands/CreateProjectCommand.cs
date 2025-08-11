using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Projects.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                UserId = request.UserId
            };

            await _projectRepository.AddAsync(project);
            return project.Id;
        }
    }
}
