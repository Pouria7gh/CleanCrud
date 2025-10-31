using CleanCrud.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var handle = "this is CQRS";

            return handle;
        }
    }
}
