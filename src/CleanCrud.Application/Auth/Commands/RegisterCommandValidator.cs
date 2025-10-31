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
            RuleFor(x => x.Email).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
}
