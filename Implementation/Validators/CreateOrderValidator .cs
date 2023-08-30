using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.ShippingAddress).NotEmpty().WithMessage("Shipping address is required.");
            RuleFor(x => x.ShippingCity).NotEmpty().WithMessage("Shipping city is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.OrderLines).NotEmpty().WithMessage("At least one order line is required.");

            RuleForEach(x => x.OrderLines).SetValidator(new CreateOrderLineValidator());
        }
    }

    public class CreateOrderLineValidator : AbstractValidator<CreateOrderLineDTO>
    {
        public CreateOrderLineValidator()
        {
            RuleFor(x => x.SizeId).NotEmpty().WithMessage("Size ID is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
