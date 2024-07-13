using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string UserName { get; set; }

        // Diferencia el tipo de usuario, admin o comun
        [Required]
        public UserType UserType { get; set; }

        // Atributos para la fecha de alta y baja de usuarios
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UserRegistrationDate { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UserDeletionDate { get; set; }

        public ICollection<Cart>Carts { get; set; }
    }
}
