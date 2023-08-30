using Application.Commands.Category;
using Application.Exceptions;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Raven.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly Context _context;
        private readonly DeleteCategoryValidator _validator;

        public DeleteCategoryCommand(Context context, DeleteCategoryValidator validator)
        {
            _context = context;
            _validator = validator;

        }

        public int Id => 14;

        public string Name => "Deleteing Category.";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            _validator.ValidateAndThrow(request);


            _context.Categories.Remove(category);
            _context.SaveChanges();


            _context.SaveChanges();
        }
    }
}
