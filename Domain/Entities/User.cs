using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Ver Required
        public string UserName { get; set; }
        // Diferencia el tipo de usuario, admin o comun
        public UserType UserType { get; set; }
        // Atributos para la fecha de alta y baja de usuarios
        public DateTime UserRegistrationDate { get; set; }
        public DateTime UserDeletionDate { get; set; }

        public ICollection<Cart>Carts { get; set; }
    }
}
