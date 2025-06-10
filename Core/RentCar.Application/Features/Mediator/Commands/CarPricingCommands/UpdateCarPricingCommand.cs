using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand : IRequest
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}