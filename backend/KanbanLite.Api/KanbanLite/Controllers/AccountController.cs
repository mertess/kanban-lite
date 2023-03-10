using KanbanLite.Core.Common;
using KanbanLite.Core.Handlers.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KanbanLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) => _mediator = mediator;

        [HttpPost("[action]")]
        public async Task<ActionResult<VoidResult>> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
