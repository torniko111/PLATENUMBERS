using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platenumbers.Application.Features.PlateNumber.Commands.CreateOrderNumber;
using Platenumbers.Application.Features.OrderNumber.Commands.DeleteOrderNumber;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platenumbers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderNumbersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderNumbersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<ReserveNumberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReserveNumberController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReserveNumberController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<string> numbers)
        {
            var orderedNumbers = new CreateOrderNumberCommand();
            orderedNumbers.Numbers = numbers;
            var response = await _mediator.Send(orderedNumbers);
            return CreatedAtAction(nameof(Get), new { id = response });

        }

        // PUT api/<ReserveNumberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ReserveNumberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteOrderNumberCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
