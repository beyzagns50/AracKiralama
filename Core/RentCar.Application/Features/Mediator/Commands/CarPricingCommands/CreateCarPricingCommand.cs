using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand : IRequest
    {
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}