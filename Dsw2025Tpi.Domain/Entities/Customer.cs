using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Customer : EntityBase
    {
        // Constructor vacío para EF
        private Customer() { }

        // Constructor de negocio
        public Customer(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre es obligatorio.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email es obligatorio.", nameof(email));

            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
