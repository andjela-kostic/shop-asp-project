using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SizeProducts
{
    public interface ICreateSizeProductCommand : ICommand<CreateSizeProductDTO>
    {
    }
}
