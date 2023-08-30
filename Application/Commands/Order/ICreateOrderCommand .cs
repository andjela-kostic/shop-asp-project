using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public interface ICreateOrderCommand : ICommand<CreateOrderDTO>
    {
    }

}
