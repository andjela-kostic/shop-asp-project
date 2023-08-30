using Application.Commands.Size;
using Application.Exceptions;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class DeleteSizeCommand : IDeleteSizeCommand
    {
        private readonly Context _context;
        private readonly DeleteSizeValidator _validator;

        public DeleteSizeCommand(Context context, DeleteSizeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 16; 
        public string Name => "Deleting Size";

        public void Execute(int request)
        {
            var size = _context.Sizes.FirstOrDefault(s => s.Id == request);

            if (size == null)
            {
                throw new EntityNotFoundException(request, typeof(Size));
            }

            _validator.ValidateAndThrow(request);

            _context.Sizes.Remove(size);
            _context.SaveChanges();
        }
    }
}