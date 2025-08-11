using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Bugs.Queries
{
    public class GetBugByIdQuery : IRequest<Bug?>
    {
        public int Id { get; set; }
    }
    public class GetBugByIdQueryHandler : IRequestHandler<GetBugByIdQuery, Bug?>
    {
        private readonly IBugRepository _bugRepository;

        public GetBugByIdQueryHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<Bug?> Handle(GetBugByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bugRepository.GetByIdAsync(request.Id);
        }
    }
}
