using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Search
{
    public class SizeProductSearch : PagedSearch
    {
        public int? SizeId { get; set; }
        public int? ProductId { get; set; }
    }
}
