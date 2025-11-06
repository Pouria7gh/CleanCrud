using CleanCrud.Application.Auth.DTOs;
using CleanCrud.Application.Common;
using CleanCrud.Application.Repositories;
using CleanCrud.Application.Services;
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
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<RegisterResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public RegisterCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Response<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();

            var userByEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (userByEmail != null)
            {
                return Response<RegisterResponseDto>.Fail("Email already exists");
            }

            var userByUserName = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (userByUserName != null)
            {
                return Response<RegisterResponseDto>.Fail("User name already exists");
            }

            var user = new ApplicationUser(request.FullName)
            {
                Email = request.Email,
                UserName = request.UserName,
            };

            var result = await _userRepository.RegisterAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return Response<RegisterResponseDto>.Fail(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            // create refresh token & access token

            var data = new RegisterResponseDto()
            {
                AccessToken = await _tokenService.GenerateToken(user),
                RefreshToken = "lol"
            };
            return Response<RegisterResponseDto>.Success(data);
        }
    }
}
