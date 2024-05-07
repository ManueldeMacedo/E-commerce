using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public string Address {  get; set; }
        public int PhoneNumber {  get; set; }
        public DateTime BirthDate { get; set; }
    }
}
