using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Stock { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Image { get; set; }

        public ICollection<Cart>Carts { get; set; }

        public Product(string Name, string Description, decimal Price, int Stock, string Image)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Stock = Stock;
            this.Image = Image;
        }
    }
}
