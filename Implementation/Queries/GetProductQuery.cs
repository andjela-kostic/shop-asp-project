using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Products;
using AutoMapper;
using DataAccess;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetProductQuery : IGetProductQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetProductQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Get Product by Id.";

        public ProductDTO Execute(int search)
        {
            var query = _context.Products
                        .Include(x => x.Category)
                        .Include(x => x.SizeProducts)
                        .ThenInclude(x => x.Size)
                        .SingleOrDefault(x => x.Id == search);

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Product));
            }

            return _mapper.Map<ProductDTO>(query);
        }


    }
}
