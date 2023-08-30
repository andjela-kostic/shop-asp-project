using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Categories;
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
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetCategoriesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Categories search.";

        public PagedResponse<CategoryDTO> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CategoryDTO, Category>(search, _mapper);
        }
    }
}
