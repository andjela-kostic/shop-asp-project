using Application.Commands.Product;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _validator;

        public CreateProductCommand(Context context, IMapper mapper, CreateProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Creating Product.";

        public void Execute(ProductCreateDTO request)
        {
            _validator.ValidateAndThrow(request);

            var product = _mapper.Map<Product>(request);

            _context.Products.Add(product);

            _context.SaveChanges();
        }
    }
}
