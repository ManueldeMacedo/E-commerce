using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos
{
    public class CartProductDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
