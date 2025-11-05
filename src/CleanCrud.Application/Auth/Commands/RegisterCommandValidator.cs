using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Auth.Commands
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(150).EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Must(p => !string.IsNullOrEmpty(p) && !p.Any(char.IsWhiteSpace)).WithMessage("Password must not contain whitespace.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[!@#$%^&*()_+\\-={}\\[\\]:;\"'<>,.?/|~`]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.UserName).NotEmpty().MaximumLength(150);
        }
    }
}
