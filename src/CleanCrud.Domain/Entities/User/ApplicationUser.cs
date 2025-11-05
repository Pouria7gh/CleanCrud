using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        private readonly List<RefreshToken> _refreshTokens = new();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        public string FullName { get; private set; }

        private ApplicationUser() {   } // EF

        public ApplicationUser(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
                throw new ArgumentNullException(nameof(fullname));

            FullName = fullname;
        }

        public void AddRefreshToken(RefreshToken token) => _refreshTokens.Add(token);
    }
}
