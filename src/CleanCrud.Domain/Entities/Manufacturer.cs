using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Domain.Entities
{
    public class Manufacturer
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }

        private Manufacturer(string name, string email)
        {
            Id = new Guid();
            Name = name;
            Email = email;
        }

        public static Manufacturer Create(string name, string email)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            return new Manufacturer(
                name.Trim(),
                email.Trim()
            );
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))  throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
