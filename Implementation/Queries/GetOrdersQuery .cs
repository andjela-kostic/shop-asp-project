using Application.DataTransfer;
using Application.Queries.Orders;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetOrdersQuery : IGetOrdersQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetOrdersQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Get Orders";

        public List<OrderWithLinesDTO> Execute(OrderSearchDTO search)
        {
            var query = _context.Orders.Include(x => x.OrderLines).Include(x=>x.User).AsQueryable();

            if (!string.IsNullOrEmpty(search.ShippingCity))
            {
                query = query.Where(x => x.ShippingCity.ToLower().Contains(search.ShippingCity.ToLower()));
            }

            if (search.UserId != 0 && search.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var orders = query.ToList();
            var orderDTOs = _mapper.Map<List<OrderWithLinesDTO>>(orders);

            return orderDTOs;
        }
    }
}
