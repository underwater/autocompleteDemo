using AutoMapper;
using backend.DataTransferObjects;
using backend.Models;

namespace backend.Mappers
{
    public class ModelsMapperProfile : Profile
    {
        public ModelsMapperProfile()
        {
            CreateMap<CityDto, City>();

            CreateMap<City, CityDto>();
        }
    }
}