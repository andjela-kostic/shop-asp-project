using Application.DataTransfer;
using DataAccess;
using Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<int>
    {
        private readonly Context _context;

        public DeleteCategoryValidator(Context context)
        {
            _context = context;

            RuleFor(categoryId => categoryId)
                .Must(CanDeleteCategory)
                .WithMessage("Cannot delete category with associated products.");
        }

        private bool CanDeleteCategory(int categoryId)
        {
            var productsInCategory = _context.Products.Any(p => p.CategoryId == categoryId);
            return !productsInCategory;
        }
    }
}
