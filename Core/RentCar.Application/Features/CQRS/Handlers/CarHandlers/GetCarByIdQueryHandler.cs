using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.CQRS.Queries.BrandQueries;
using RentCar.Application.Features.CQRS.Queries.CarQueries;
using RentCar.Application.Features.CQRS.Results.BrandResults;
using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandID = values.BrandID,
                BigImageUrl = values.BigImageUrl,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                CarID = values.CarID,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Model = values.Model,
                Km = values.Km,
                Luggage = values.Luggage
            };
        }
    }
}
