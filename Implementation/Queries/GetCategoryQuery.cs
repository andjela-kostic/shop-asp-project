using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Categories;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetCategoryQuery : IGetCategoryQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetCategoryQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get Category by Id.";

        public CategoryDTO Execute(int search)
        {
            var query = _context.Categories.Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            return _mapper.Map<CategoryDTO>(query);
        }
    }
}
