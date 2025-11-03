using CleanCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<string> RegisterAsync(string fullName, string email, string password, string username);

        public Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
