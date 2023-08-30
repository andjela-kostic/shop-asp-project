using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductCreateDTO>
    {
        public CreateProductValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Products.Any(b => b.Name.ToLower() == name.ToLower())).WithMessage("Product with that name is already in database.");
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
