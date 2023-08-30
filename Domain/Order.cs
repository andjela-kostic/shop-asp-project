using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set;}
        public string Phone { get; set; }
        public decimal Price { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
