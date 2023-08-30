using Application.DataTransfer;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Sizes
{
    public interface IGetSizeQuery : IQuery<int, SizeDTO>
    {
    }
}