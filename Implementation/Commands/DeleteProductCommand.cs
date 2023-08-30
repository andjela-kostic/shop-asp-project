using Application.Commands.Product;
using Application.Exceptions;
using AutoMapper;
using Domain;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly Context _context;

        public DeleteProductCommand(Context context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Deleting Product.";

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException(request, typeof(Product));
            }

            product.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
