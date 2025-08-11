using BugTracker.Application.Interfaces;
using BugTracker.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Bugs.Commands
{
    public class UpdateBugCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ProjectId { get; set; }
    }
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand, Unit>
    {
        private readonly IBugRepository _bugRepository;

        public UpdateBugCommandHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<Unit> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _bugRepository.GetByIdAsync(request.Id);
            if (bug == null)
                throw new Exception("Bug not found");

            bug.Title = request.Title;
            bug.Description = request.Description;
            bug.Status = request.Status;
            bug.ProjectId = request.ProjectId;

            await _bugRepository.UpdateAsync(bug);
            return Unit.Value;
        }
    }

}
