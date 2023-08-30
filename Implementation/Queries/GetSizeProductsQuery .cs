using Application.DataTransfer;
using Application.Queries.SizeProducts;
using Application.Queries;
using Application.Search;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Implementation.Queries
{
    public class GetSizeProductsQuery : IGetSizeProductsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetSizeProductsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 6; 

        public string Name => "Get all size products.";

        public PagedResponse<SizeProductDTO> Execute(SizeProductSearch search)
        {
            var query = _context.SizesProducts.AsQueryable();

            if (search.SizeId.HasValue)
            {
                query = query.Where(x => x.SizeId == search.SizeId.Value);
            }

            if (search.ProductId.HasValue)
            {
                query = query.Where(x => x.ProductId == search.ProductId.Value);
            }

            

            var sizeProducts = query.ToList();
            var sizeProductDTOs = _mapper.Map<List<SizeProductDTO>>(sizeProducts);
            foreach (var item in sizeProductDTOs)
            {
                var count = _context.OrderLines
                .Count(ol => ol.SizeId == item.SizeId && ol.ProductId == item.ProductId);
                item.OrderLinesCount = count;
            }
            return new PagedResponse<SizeProductDTO>
            {
                Items = sizeProductDTOs,
                TotalCount = sizeProductDTOs.Count
            };
        }
    }
}
