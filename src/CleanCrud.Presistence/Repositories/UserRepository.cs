using CleanCrud.Application.Repositories;
using CleanCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Presistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync(string fullName, string email, string password, string username)
        {
            throw new NotImplementedException();
        }
    }
}
