using BugTracker.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Bugs.Commands
{
    public class DeleteBugCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteBugCommandHandler : IRequestHandler<DeleteBugCommand, Unit>
    {
        private readonly IBugRepository _bugRepository;

        public DeleteBugCommandHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<Unit> Handle(DeleteBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _bugRepository.GetByIdAsync(request.Id);
            if (bug == null)
                throw new Exception("Bug not found");

            await _bugRepository.DeleteAsync(bug);
            return Unit.Value;
        }
    }

}
