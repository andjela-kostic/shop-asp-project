using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Size : BaseEntity
    {
        public string Value { get; set; }
        public ICollection<SizeProduct> SizeProducts { get; set; } = new List<SizeProduct>();

    }
}
