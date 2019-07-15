using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IUnitOfWork
    {
         ICitiesRepository CitiesRepository { get; }

         void Commit();

         Task CommitAsync(); 
    }
}