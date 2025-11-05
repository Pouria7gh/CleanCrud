using CleanCrud.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<IdentityResult> RegisterAsync(ApplicationUser user, string password);

        public Task<ApplicationUser> GetUserByEmailAsync(string email);

        public Task<ApplicationUser> GetUserByUserNameAsync(string userName);
    }
}
