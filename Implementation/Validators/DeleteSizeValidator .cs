using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class DeleteSizeValidator : AbstractValidator<int>
    {
        private readonly Context _context;

        public DeleteSizeValidator(Context context)
        {
            _context = context;

            RuleFor(sizeId => sizeId)
                .Must(CanDeleteSize)
                .WithMessage("Cannot delete size with associated products.");
        }

        private bool CanDeleteSize(int sizeId)
        {
            var productsWithSize = _context.SizesProducts.Any(ps => ps.SizeId == sizeId);
            return !productsWithSize;
        }
    }
}
