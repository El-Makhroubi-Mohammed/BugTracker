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
    public class GetAllProjectsQuery : IRequest<List<Project>> { }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<Project>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }

}
