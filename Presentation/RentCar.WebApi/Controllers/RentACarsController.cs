using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.RentACarQueries;
using RentCar.Persistence.Context;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RentCarContext _context;

        public RentACarsController(IMediator mediator, RentCarContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationID, bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                Available = available,
                LocationID = locationID
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }

        [HttpPut("SetAvailable/{id}")]
        public async Task<IActionResult> SetAvailable(int id, [FromQuery] bool available)
        {
            // Burada repository veya context ile ilgili RentACar kaydını bul
            var rentACar = await _context.RentACars.FindAsync(id);
            if (rentACar == null)
                return NotFound();

            rentACar.Available = available;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
