using Application.DataTransfer;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Log
{
    public interface IGetUseCaseLogQuery : IQuery<int, UseCaseLogDto>
    {
    }
}
