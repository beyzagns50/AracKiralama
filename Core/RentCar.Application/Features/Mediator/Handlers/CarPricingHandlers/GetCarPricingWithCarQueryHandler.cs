using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Features.Mediator.Results.LocationResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                CarPricingId = x.CarPricingID,
                Brand = x.Car.Brand.Name,
                BrandId = x.Car.BrandID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                Fuel=x.Car.Fuel,
                Transmission = x.Car.Transmission, // Assuming Transmission is a property of Car
                CarId =x.CarID
            }).ToList();
        }
    }
}
