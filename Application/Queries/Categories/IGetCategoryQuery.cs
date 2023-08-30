using Application.DataTransfer;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Categories
{
    public interface IGetCategoryQuery : IQuery<int,CategoryDTO>
    {
    }
}
