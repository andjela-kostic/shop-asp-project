using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DataTransfer
{
    public class OrderLineDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

    }

    public class CreateOrderLineDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
