using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderLine : BaseEntity
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public SizeProduct SizeProducts { get; set; }
        public Order Order { get; set; }
    }
}
