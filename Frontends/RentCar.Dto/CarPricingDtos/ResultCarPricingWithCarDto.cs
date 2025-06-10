using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Dto.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Fuel { get; set; } // <-- Eklendi
        public string Transmission { get; set; } // <-- Eklendi, eğer gerekli ise
    }
}
