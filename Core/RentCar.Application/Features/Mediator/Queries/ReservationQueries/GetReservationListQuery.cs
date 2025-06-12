using MediatR;
using RentCar.Application.Features.Mediator.Results.ReservationResults;
using System.Collections.Generic;

namespace RentCar.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationListQuery : IRequest<List<GetReservationListQueryResult>>
    {
    }
}   