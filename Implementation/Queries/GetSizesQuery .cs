using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Sizes;
using Application.Search;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetSizesQuery : IGetSizesQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetSizesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Sizes search.";

        public PagedResponse<SizeDTO> Execute(SizeSearch search)
        {
            var query = _context.Sizes.AsQueryable();

            if (!string.IsNullOrEmpty(search.Value))
            {
                query = query.Where(x => x.Value.ToLower().Contains(search.Value.ToLower()));
            }

            return query.Paged<SizeDTO, Size>(search, _mapper);
        }

        public PagedResponse<SizeDTO> Execute()
        {
            var sizes = _context.Sizes.ToList();
            var sizeDTOs = _mapper.Map<List<SizeDTO>>(sizes);
            return new PagedResponse<SizeDTO>
            {
                Items = sizeDTOs,
                TotalCount = sizeDTOs.Count
            };
        }
    }
}