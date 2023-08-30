using Application;
using Application.Commands.Order;
using Application.DataTransfer;
using Application.Queries.Categories;
using Application.Queries.Orders;
using Application.Search;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase

    {
        private readonly UseCaseExecutor _executor;

        public OrderController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<OrderController>B
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearchDTO search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDTO dto, [FromServices] ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
