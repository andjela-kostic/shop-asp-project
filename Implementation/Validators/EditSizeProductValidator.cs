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
    public class EditSizeProductValidator : AbstractValidator<CreateSizeProductDTO>
    {
        private readonly Context _context;
        public EditSizeProductValidator(Context context)
        {

            RuleFor(x => x.SizeId).NotEmpty().WithMessage("Size ID is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be a non-negative value.");

            RuleFor(x => x).Must(SizeProductCombinationExists)
                .WithMessage("SizeProduct combination does not exist.");
        }
        private bool SizeProductCombinationExists(CreateSizeProductDTO dto)
        {
            return _context.SizesProducts.Any(sp => sp.SizeId == dto.SizeId && sp.ProductId == dto.ProductId);
        }
    }
}
