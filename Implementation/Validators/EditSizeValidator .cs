using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class EditSizeValidator : AbstractValidator<SizeDTO>
    {
        public EditSizeValidator()
        {
            RuleFor(x => x.Value).NotEmpty().WithMessage("Size value is required.");
        }
    }
}
