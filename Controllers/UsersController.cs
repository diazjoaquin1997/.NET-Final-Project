using Application.Contracts;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTeamAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList([FromQuery] GetUserListRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response.UserList);
        }
    }
}
