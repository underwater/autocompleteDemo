using System.Threading.Tasks;
using backend.Data;

namespace backend.Repositories
{
    // https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICitiesRepository CitiesRepository => new CitiesRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}