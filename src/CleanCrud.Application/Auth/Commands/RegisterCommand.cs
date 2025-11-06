using CleanCrud.Application.Auth.DTOs;
using CleanCrud.Application.Common;
using MediatR;

namespace CleanCrud.Application.Auth.Commands
{
    public class RegisterCommand : IRequest<Response<RegisterResponseDto>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
