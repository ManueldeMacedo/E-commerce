using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
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
