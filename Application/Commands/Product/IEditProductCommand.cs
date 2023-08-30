using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Product
{
    public interface IEditProductCommand : ICommand<ProductEditDTO>
    {
    }
}
