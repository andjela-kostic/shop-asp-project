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
    public class CreateSizeValidator : AbstractValidator<CreateSizeDTO>
    {
        public CreateSizeValidator(Context context)
        {
            RuleFor(x => x.Value).NotEmpty().WithMessage("Size value is required.").DependentRules(() =>
            {
                RuleFor(x => x.Value).Must(value => !context.Sizes.Any(s => s.Value.ToLower() == value.ToLower()))
                    .WithMessage("Size with that value already exists.");
            });
        }
    }
}