using CleanCrud.Api.DTOs.Auth;
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
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _mediator.Send(new RegisterCommand()
            { 
                FullName = dto.FullName,
                Password = dto.Password,
                Email = dto.Email,
                UserName = dto.UserName
            });

            return Ok(result);
        }
    }
}
