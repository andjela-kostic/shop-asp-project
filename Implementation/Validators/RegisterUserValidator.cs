using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserCreateDto>
    {

        public RegisterUserValidator(Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email name is required.").EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password name is required.").MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
