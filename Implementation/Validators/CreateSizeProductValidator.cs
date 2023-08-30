using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateSizeProductValidator : AbstractValidator<CreateSizeProductDTO>
    {
        private readonly Context _context;

        public CreateSizeProductValidator(Context context)
        {
            _context = context;

            RuleFor(dto => dto.SizeId)
                .Must(SizeExists)
                .WithMessage("Size with the provided ID does not exist.");

            RuleFor(dto => dto.ProductId)
                .Must(ProductExists)
                .WithMessage("Product with the provided ID does not exist.");

            RuleFor(dto => new SizeProductDTO { SizeId = dto.SizeId, ProductId = dto.ProductId })
                .Must(SizeProductCombinationDoesNotExist)
                .WithMessage("SizeProduct combination already exists.");
        }

        private bool SizeExists(int sizeId)
        {
            return _context.Sizes.Any(s => s.Id == sizeId);
        }

        private bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        private bool SizeProductCombinationDoesNotExist(SizeProductDTO dto)
        {
            return !_context.SizesProducts.Any(sp => sp.SizeId == dto.SizeId && sp.ProductId == dto.ProductId);
        }
    }
}
