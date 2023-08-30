using Application.DataTransfer;
using Application.Queries.Sizes;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Sizes
{
    public interface IGetSizesQuery : IQuery<SizeSearch, PagedResponse<SizeDTO>>
    {
        PagedResponse<SizeDTO> Execute();
    }
}