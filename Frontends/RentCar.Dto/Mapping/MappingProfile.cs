using AutoMapper;
using RentCar.Domain.Entities;
using RentCar.Dto.AdminRentACar;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AdminRentACarDto, RentACar>().ReverseMap();
    }
}

