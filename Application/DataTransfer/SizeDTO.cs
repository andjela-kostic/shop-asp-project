using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class SizeDTO
    {
        public int Id { get;set; }
        public string? Value { get;set; }
    }

    public class CreateSizeDTO
    {
        public string Value { get; set; }
    }
}
