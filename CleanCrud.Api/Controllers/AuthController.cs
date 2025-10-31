using CleanCrud.Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCrud.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register()
        {
            var result = await _mediator.Send(new RegisterCommand() { FullName = "admin", Password = "123", Email = "123" });
            return Ok(result);
        }
    }
}
