using Application.Queries.SizeProducts;
using Application.Search;
using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.SizeProducts;
using Application.DataTransfer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Commands.Size;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeProductController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public SizeProductController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        [AllowAnonymous]
        // GET: api/<SizeProductController>
        [HttpGet]
        public IActionResult Get([FromQuery] SizeProductSearch search, [FromServices] IGetSizeProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeProductDTO dto, [FromServices] ICreateSizeProductCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] CreateSizeProductDTO dto, [FromServices] IEditSizeProductCommand command)
        {

            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<SizeProductController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteSizeProductDTO dto, [FromServices] IDeleteSizeProductCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
    }
}
