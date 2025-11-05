using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Domain.Entities.User
{
    public class RefreshToken
    {
        public int Id { get; private set; }

        public string Token { get; private set; }
        public string UserId { get; private set; }
        public ApplicationUser User { get; private set; }

        public DateTime Expires { get; private set; }
        public DateTime Created { get; private set; }
        public string CreatedByIp { get; private set; }

        public DateTime? Revoked { get; private set; }
        public string RevokedByIp { get; private set; }
        public string ReplacedByToken { get; private set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;

        private RefreshToken() { }

        public RefreshToken(string token, string userId, DateTime expires, string createdByIp)
        {
            Token = token;
            UserId = userId;
            Expires = expires;
            Created = DateTime.UtcNow;
            CreatedByIp = createdByIp;
        }

        public void Revoke(string ipAddress, string replacedByToken = null)
        {
            if (IsRevoked) return;
            Revoked = DateTime.UtcNow;
            RevokedByIp = ipAddress;
            ReplacedByToken = replacedByToken;
        }
    }
}
