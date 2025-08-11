using BugTracker.Application.Dtos.Bugs;
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
    public class GetAllBugsQuery : IRequest<List<Bug>>
    {
    }
    public class GetAllBugsQueryHandler : IRequestHandler<GetAllBugsQuery, List<Bug>>
    {
        private readonly IBugRepository _bugRepository;

        public GetAllBugsQueryHandler(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<List<Bug>> Handle(GetAllBugsQuery request, CancellationToken cancellationToken)
        {
            return await _bugRepository.GetAllAsync();
        }
    }

}
