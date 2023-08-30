using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SizeProduct
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Size Size { get; set; }
        public Product Product { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    }
}
