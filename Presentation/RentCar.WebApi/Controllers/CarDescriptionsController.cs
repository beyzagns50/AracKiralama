﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentCar.Application.Features.Mediator.Queries.LocationQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarDescriptionByCarId(int id)
        {
            var values =await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(values);
        }
    }
}