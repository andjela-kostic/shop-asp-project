using Application.Commands.Product;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EditProductCommand : IEditProductCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly EditProductValidator _validator;

        public EditProductCommand(Context context, IMapper mapper, EditProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Editing Product.";

        public void Execute(ProductEditDTO request)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();

            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Product));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, product);

            _context.SaveChanges();
        }
    }
}
