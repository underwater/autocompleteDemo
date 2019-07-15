using System;
using System.Linq;
using backend.Data;
using backend.Models;

namespace backend.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly ApplicationDbContext _context;

        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAsync(City city)
        {
            _context.Add(city);
        }

        public City Get(Guid id)
        {
           return _context.Find<City>(id);
        }

        public IQueryable<City> GetAll()
        {
            return _context.Set<City>();
        }

        public void Remove(City city)
        {
            _context.Remove(city);
        }

        public void Update(City city)
        {
            _context.Update(city);
        }
    }
}