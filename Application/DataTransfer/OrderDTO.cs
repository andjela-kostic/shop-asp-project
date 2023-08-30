using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{

    public class OrderSearchDTO
    {
        public string? ShippingCity { get; set; }
        public int? UserId { get; set; }
    }

    public class OrderWithLinesDTO
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public UserDTO User { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; }
    }

    public class CreateOrderDTO
    {
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public List<CreateOrderLineDTO> OrderLines { get; set; }
    }

    
}
