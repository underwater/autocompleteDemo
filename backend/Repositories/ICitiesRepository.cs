using System;
using System.Linq;
using backend.Models;

namespace backend.Repositories
{
    public interface ICitiesRepository
    {
        void CreateAsync(City city);

        void Update(City city);

        void Remove(City city);

        IQueryable<City> GetAll();  

        City Get(Guid id);
    }
}