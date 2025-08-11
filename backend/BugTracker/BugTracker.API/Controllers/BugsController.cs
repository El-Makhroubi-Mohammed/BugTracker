using BugTracker.Application.Dtos.Bugs;
using BugTracker.Application.Features.Bugs.Commands;
using BugTracker.Application.Features.Bugs.Queries;
using BugTracker.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BugsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var bugs = await _mediator.Send(new GetAllBugsQuery());
            var bugsByProject = bugs.Where(b => b.ProjectId == id).ToList();
            return Ok(bugsByProject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bug = await _mediator.Send(new GetBugByIdQuery { Id = id});
            return bug == null ? NotFound() : Ok(bug);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBugCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBugCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBugCommand { Id = id });
            return NoContent();
        }
    }
}
