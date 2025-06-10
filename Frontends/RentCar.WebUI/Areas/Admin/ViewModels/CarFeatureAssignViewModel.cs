using RentCar.Dto.FeatureDtos;
using System.Collections.Generic;

namespace RentCar.WebUI.Areas.Admin.ViewModels
{
    public class CarFeatureAssignViewModel
    {
        public int CarId { get; set; }
        public List<ResultFeatureDto> AllFeatures { get; set; }
        public List<int> AssignedFeatureIds { get; set; }
    }
}