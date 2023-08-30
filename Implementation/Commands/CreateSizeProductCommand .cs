using Application.Commands.SizeProducts;
using Application.DataTransfer;
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
    public class CreateSizeProductCommand : ICreateSizeProductCommand
    {
        private readonly Context _context;
        private readonly CreateSizeProductValidator _validator;

        public CreateSizeProductCommand(Context context, CreateSizeProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Creating size product.";

        public void Execute(CreateSizeProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var sizeProduct = new SizeProduct
            {
                SizeId = request.SizeId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            _context.SizesProducts.Add(sizeProduct);
            _context.SaveChanges();
        }
    }
}