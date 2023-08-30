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
    public class DeleteSizeProductCommand : IDeleteSizeProductCommand
    {
        private readonly Context _context;
        private readonly DeleteSizeProductValidator _validator;

        public DeleteSizeProductCommand(Context context, DeleteSizeProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 22; 

        public string Name => "Delete Size Product";

        public void Execute(DeleteSizeProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var sizeProduct = _context.SizesProducts.FirstOrDefault(sp => sp.SizeId == request.SizeId && sp.ProductId == request.ProductId);

            if (sizeProduct == null)
            {
                throw new EntityNotFoundException(request.SizeId, typeof(SizeProduct));
            }

            _context.SizesProducts.Remove(sizeProduct);
            _context.SaveChanges();
        }
    }
}
