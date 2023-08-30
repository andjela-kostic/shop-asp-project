using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class SizeProductDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderLinesCount { get; set; }
    }

    public class CreateSizeProductDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class DeleteSizeProductDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
    }

}
