using Application.Commands.Category;
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
    public class EditCategoryCommand : IEditCategoryCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly EditCategoryValidator _validator;

        public EditCategoryCommand(Context context, IMapper mapper, EditCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 17;

        public string Name => "Category Brand.";

        public void Execute(CategoryDTO request)
        {
            var category = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();

            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, category);

            _context.SaveChanges();
        }
    }
}
