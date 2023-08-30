using Application;
using Application.Commands.Order;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;

        public CreateOrderCommand(Context context, IMapper mapper, CreateOrderValidator validator, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 24; 

        public string Name => "Create Order";

        public void Execute(CreateOrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            var order = _mapper.Map<Order>(request);
            order.UserId = _actor.Id;
            order.OrderDate = DateTime.Now;

            var price = 0.00M;

            foreach (var o in request.OrderLines)
            {

                var ol = _mapper.Map<OrderLine>(o);

                ol.SizeId = o.SizeId;
                ol.ProductId = o.ProductId;
                ol.Quantity = o.Quantity;

                var p = _context.Products.Find(o.ProductId);

                if(p.Price != null)
                {
                    price= price+(p.Price*ol.Quantity);

                }
                ol.SizeProduct = _context.SizesProducts.FirstOrDefault(sp => sp.SizeId == o.SizeId && sp.ProductId == o.ProductId);
                order.OrderLines.Add(ol);
            }
            order.Price = price;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
