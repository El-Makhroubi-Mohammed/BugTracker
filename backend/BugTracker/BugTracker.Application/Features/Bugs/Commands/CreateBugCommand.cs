using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using BugTracker.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Bugs.Commands
{
    public class CreateBugCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ProjectId { get; set; }
    }
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IBugRepository _bugRepository;

        public CreateBugCommandHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                ProjectId = request.ProjectId
            };

            await _bugRepository.AddAsync(bug);
            return bug.Id;
        }
    }

}
