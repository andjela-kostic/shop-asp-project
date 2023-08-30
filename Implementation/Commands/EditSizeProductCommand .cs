using Application.Commands.SizeProducts;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EditSizeProductCommand : IEditSizeProductCommand
    {
        private readonly Context _context;
        private readonly EditSizeProductValidator _validator;

        public EditSizeProductCommand(Context context, EditSizeProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Edit Size Product";

        public void Execute(CreateSizeProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var sizeProduct = _context.SizesProducts.FirstOrDefault(sp => sp.SizeId == request.SizeId && sp.ProductId==request.ProductId);

            if (sizeProduct == null)
            {
                throw new EntityNotFoundException(request.SizeId, typeof(SizeProduct));
            }

            sizeProduct.SizeId = request.SizeId;
            sizeProduct.ProductId = request.ProductId;
            sizeProduct.Quantity = request.Quantity;

            _context.SaveChanges();
        }
    }
}
