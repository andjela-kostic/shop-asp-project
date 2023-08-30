using Application;
using Application.Commands.Size;
using Application.DataTransfer;
using Application.Queries.Sizes;
using Application.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public SizeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] SizeSearch search, [FromServices] IGetSizesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSizeQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeDTO dto, [FromServices] ICreateSizeCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SizeDTO dto, [FromServices] IEditSizeCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSizeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}