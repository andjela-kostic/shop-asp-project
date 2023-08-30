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
    public class EditCategoryValidator : AbstractValidator<CategoryDTO>
    {
        public EditCategoryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !context.Categories.Any(b => b.Name == name && b.Id != dto.Id)).WithMessage(b => $"Category with name {b.Name} already exists.");
            });
        }
    }
}
