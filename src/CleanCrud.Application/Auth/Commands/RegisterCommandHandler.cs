using CleanCrud.Application.Common;
using CleanCrud.Application.Repositories;
using CleanCrud.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userExists != null)
            {
                return "user already exists";
            }

            var result = await _userRepository.RegisterAsync(request.FullName, request.Email, request.Password, request.Username);

            return result;
        }
    }
}
