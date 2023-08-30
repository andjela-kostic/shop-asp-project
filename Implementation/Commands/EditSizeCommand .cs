using Application.Commands.Size;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
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
    public class EditSizeCommand : IEditSizeCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly EditSizeValidator _validator;

        public EditSizeCommand(Context context, IMapper mapper, EditSizeValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 19; 
        public string Name => "Editing Size";

        public void Execute(SizeDTO request)
        {
            var size = _context.Sizes.FirstOrDefault(s => s.Id == request.Id);

            if (size == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Size));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, size);

            _context.SaveChanges();
        }
    }
}