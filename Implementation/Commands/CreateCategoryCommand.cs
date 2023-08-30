using Application.Commands.Category;
using Application.DataTransfer;
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
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateCategoryValidator _validator;

        public CreateCategoryCommand(Context context, IMapper mapper, CreateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Creating Category.";

        public void Execute(CreateCategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = _mapper.Map<Category>(request);

            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
