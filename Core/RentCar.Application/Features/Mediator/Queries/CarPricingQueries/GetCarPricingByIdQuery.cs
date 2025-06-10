using MediatR;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;

namespace RentCar.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery : IRequest<GetCarPricingWithCarQueryResult>
    {
        public int Id { get; set; }
        public GetCarPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}