using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.ReservationCommands;
using RentCar.Application.Features.Mediator.Queries.ReservationQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon başarıyla eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> GetReservationList()
        {
            var result = await _mediator.Send(new GetReservationListQuery());
            return Ok(result);
        }
    }
}
