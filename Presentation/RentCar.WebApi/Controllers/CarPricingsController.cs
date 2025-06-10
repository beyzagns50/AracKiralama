using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.CarPricingCommands;
using RentCar.Application.Features.Mediator.Queries.CarPricingQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // List all car pricings with car info
        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }

        // List all car pricings with time period info
        [HttpGet("GetCarPricingWithTimePeriodList")]
        public async Task<IActionResult> GetCarPricingWithTimePeriodList()
        {
            var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Ok(values);
        }

        // Get a single car pricing by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricingById(int id)
        {
            var value = await _mediator.Send(new GetCarPricingByIdQuery(id));
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        // Create a new car pricing
        [HttpPost]
        public async Task<IActionResult> CreateCarPricing([FromBody] CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // Update an existing car pricing
        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing([FromBody] UpdateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // Delete a car pricing by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPricing(int id)
        {
            await _mediator.Send(new RemoveCarPricingCommand(id));
            return Ok();
        }
    }
}