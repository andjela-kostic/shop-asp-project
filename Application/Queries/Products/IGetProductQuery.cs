using Application.DataTransfer;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public interface IGetProductQuery : IQuery<int, ProductDTO>
    {
    }
}
