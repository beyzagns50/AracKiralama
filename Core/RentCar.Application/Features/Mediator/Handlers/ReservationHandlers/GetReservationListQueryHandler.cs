using MediatR;
using RentCar.Application.Features.Mediator.Queries.ReservationQueries;
using RentCar.Application.Features.Mediator.Results.ReservationResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RentCar.Application.Features.Mediator.Handlers.ReservationHandlers;

namespace RentCar.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationListQueryHandler : IRequestHandler<GetReservationListQuery, List<GetReservationListQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationListQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationListQueryResult>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetAllAsync();
            return reservations.Select(x => new GetReservationListQueryResult
            {
                ReservationID = x.ReservationID,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                PickUpLocationID = x.PickUpLocationID ?? 0,
                DropOffLocationID = x.DropOffLocationID ?? 0,
                CarID = x.CarID,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                Description = x.Description
            }).ToList();
        }
    }
}