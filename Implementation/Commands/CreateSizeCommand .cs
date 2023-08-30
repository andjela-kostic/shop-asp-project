using Application.Commands.Size;
using Application.DataTransfer;
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
    public class CreateSizeCommand : ICreateSizeCommand
    {
        private readonly Context _context;
        private readonly CreateSizeValidator _validator;

        public CreateSizeCommand(Context context, CreateSizeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Creating Size.";

        public void Execute(CreateSizeDTO request)
        {
            _validator.ValidateAndThrow(request);

            var size = new Size
            {
                Value = request.Value
            };

            _context.Sizes.Add(size);
            _context.SaveChanges();
        }
    }
}