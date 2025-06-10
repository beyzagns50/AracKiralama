using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public string Fuel { get; set; } // Added for fuel type
        public string Transmission { get; set; } // Added for transmission type, if needed
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
