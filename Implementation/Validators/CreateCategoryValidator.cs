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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Categories.Any(b => b.Name.ToLower() == name.ToLower()))
                .WithMessage("Category with that name is already in database.");
            });
        }
    }
}
