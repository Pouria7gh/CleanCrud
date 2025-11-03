using MediatR;

namespace CleanCrud.Application.Auth.Commands
{
    public class RegisterCommand : IRequest<string>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
