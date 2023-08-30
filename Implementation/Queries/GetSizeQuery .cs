using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Sizes;
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
    public class GetSizeQuery : IGetSizeQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetSizeQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Get Size by Id.";

        public SizeDTO Execute(int search)
        {
            var query = _context.Sizes.Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Size));
            }

            return _mapper.Map<SizeDTO>(query);
        }
    }
}