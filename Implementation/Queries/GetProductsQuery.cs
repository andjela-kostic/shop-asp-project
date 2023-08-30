using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Products;
using Application.Search;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Implementation.Queries
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetProductsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Products search.";

        public PagedResponse<ProductDTO> Execute(ProductSearch search)
        {
            var query = _context.Products.Include(x=>x.Category).Include(x=>x.SizeProducts).ThenInclude(x=>x.Size).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            

            var result = query.ToList();

            return query.Paged<ProductDTO, Product>(search, _mapper);
        }
    }
}
