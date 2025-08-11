using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Projects.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public int Id { get; set; }
    }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Project?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }

}
