using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class RemoveCarPricingCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveCarPricingCommand(int id)
        {
            Id = id;
        }
    }
}