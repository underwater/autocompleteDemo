using System;
using System.Collections.Generic;
using AutoMapper;
using backend.DataTransferObjects;
using backend.Repositories;
using System.Linq;
using backend.Models;

namespace backend.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitiesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void CreateCity(CityDto cityDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCity(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CityDto> GetCitiesByName(string searchText)
        {
            var cities = _unitOfWork.CitiesRepository
                        .GetAll()
                        .Where(x => x.Name.ToUpperInvariant().Contains(searchText.ToUpperInvariant()));

            var citiesDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
            return citiesDtos;
        }

        public IEnumerable<CityDto> GetFavoriteCities()
        {
            var favoriteCities = _unitOfWork.CitiesRepository.GetAll()
                    .Where(x => x.IsFavorite);

            var favoriteCitiesDto = _mapper.Map<IEnumerable<CityDto>>(favoriteCities);

            return favoriteCitiesDto;
        }

        public void UpdateCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _unitOfWork.CitiesRepository.Update(city);
            _unitOfWork.Commit();
        }
    }
}