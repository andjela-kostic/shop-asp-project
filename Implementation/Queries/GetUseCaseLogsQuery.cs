using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Log;
using Application.Search;
using AutoMapper;
using Domain;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetUseCaseLogsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Search UseCaseLogs.";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Actor) && !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Data) && !string.IsNullOrWhiteSpace(search.Data))
            {
                query = query.Where(x => x.Data.ToLower().Contains(search.Data.ToLower()));
            }

            return query.Paged<UseCaseLogDto, UseCaseLog>(search, _mapper);
        }
    }
}
