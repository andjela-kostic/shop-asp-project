using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Log;
using Application.Search;
using AutoMapper;
using Domain;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetUseCaseLogQuery : IGetUseCaseLogQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetUseCaseLogQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Get UseCaseLogs by Id.";

        public UseCaseLogDto Execute(int search)
        {
            var query = _context.UseCaseLogs.Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(UseCaseLog));
            }

            return _mapper.Map<UseCaseLogDto>(query);
        }
    }
}
