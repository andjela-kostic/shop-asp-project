using Application.DataTransfer;
using Azure.Core;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class DeleteSizeProductValidator : AbstractValidator<DeleteSizeProductDTO>
    {
        private readonly Context _context;

        public DeleteSizeProductValidator(Context context)
        {
            _context = context;

            RuleFor(x => x)
                .Must(SizeProductExists)
                .WithMessage("SizeProduct does not exist.");
        }

        private bool SizeProductExists(DeleteSizeProductDTO dto)
        {
            return _context.SizesProducts.Any(sp => sp.SizeId == dto.SizeId && sp.ProductId == dto.ProductId);
        }
    }
}
