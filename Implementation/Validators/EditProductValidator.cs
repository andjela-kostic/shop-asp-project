using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class EditProductValidator : AbstractValidator<ProductEditDTO>
    {
        public EditProductValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !context.Products.Any(p => p.Name == name && p.Id != dto.Id)).WithMessage(p => $"Product with name {p.Name} already exists.");
            });
            RuleFor(x => x.Image).NotEmpty().WithMessage("ImageUrl is required.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").DependentRules(() =>
            {
                RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be above 0.");
            });

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required.").DependentRules(() =>
            {
                RuleFor(x => x.CategoryId).Must(id => context.Categories.Any(c => c.Id == id))
                .WithMessage("Category with that id doesn't exist in database.");
            });
        }
    }
}
