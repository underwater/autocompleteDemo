using System.Collections.Generic;
using backend.DataTransferObjects;

namespace backend.Services
{
    public interface ICitiesService
    {
         IEnumerable<CityDto> GetCitiesByName(string searchText);
         IEnumerable<CityDto> GetFavoriteCities();
         void CreateCity(CityDto cityDto);
         void UpdateCity(CityDto cityDto);
         void DeleteCity(string id);
    }
}