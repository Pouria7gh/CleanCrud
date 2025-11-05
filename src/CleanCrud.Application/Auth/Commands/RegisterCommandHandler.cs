using CleanCrud.Application.Common;
using CleanCrud.Application.Repositories;
using CleanCrud.Domain.Entities;
using CleanCrud.Domain.Entities.User;
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
            var userByEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userByEmail != null)
            {
                return "user already exists";
            }

            var userByUserName = await _userRepository.GetUserByUserNameAsync(request.UserName);

            if (userByUserName != null)
            {
                return "username exists";
            }

            var user = new ApplicationUser(request.FullName)
            {
                Email = request.Email,
                UserName = request.UserName,
            };

            var result = await _userRepository.RegisterAsync(user, request.Password);

            // refactor this later
            if (result.Succeeded)
                return "Registration was successful";
            else
                return "Registeration was not successful";
        }
    }
}
