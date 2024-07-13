using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Order { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int AmountProduct { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double TotalPrice { get; set; }

        public User User { get; set; }
        public TypePayment TypePayment { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public Cart() { }

        public Cart(int userId, int order, int amountProduct, ICollection<CartProduct> cartProducts, double totalPrice, TypePayment typePayment)
        {
            UserId = userId;
            Order = order;
            AmountProduct = amountProduct;
            CartProducts = cartProducts;
            TotalPrice = totalPrice;
            TypePayment = typePayment;
        }
    }
}
