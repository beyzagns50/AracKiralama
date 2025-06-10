using RentCar.Dto.CarPricingDtos;
using RentCar.Dto.CarFeatureDtos;
using System.Collections.Generic;

namespace RentCar.WebUI.ViewModels
{
    public class CarWithFeaturesViewModel
    {
        public ResultCarPricingWithCarDto Car { get; set; }
        public List<ResultCarFeatureByCarIdDto> Features { get; set; }
    }
}