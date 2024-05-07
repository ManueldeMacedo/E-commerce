using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
    public class Cart
    {
        public int Order { get; set; }
        public int AmountProduct { get; set; }
        public ICollection<Product> ListProducts { get; set; }
        public double TotalPrice { get; set; }
        public TypePayment typePayment { get; set; }

    }

}
