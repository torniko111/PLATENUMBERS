using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platenumbers.Application.Features.PlateNumber.Commands.CreatePlateNumber;
using Platenumbers.Application.Features.PlateNumber.Queries.GetAllPlateNumbers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platenumbers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateNumbersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlateNumbersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<PlateNumbersController>
        [HttpGet]
        public async Task<List<PlateNumberDto>> Get()
        {
            var plateNumbers = await _mediator.Send(new GetPlateNumbersQuery());
            return plateNumbers;
        }

        // GET api/<PlateNumbersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlateNumbersController>
        [HttpPost]
        public async Task<ActionResult> Post(CreatePlateNumberCommand plateNumber)
        {
            var response = await _mediator.Send(plateNumber);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<PlateNumbersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlateNumbersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
