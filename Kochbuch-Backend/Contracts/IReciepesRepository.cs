using Kochbuch_Backend.Data;

namespace Kochbuch_Backend.Contracts
{
    public interface IReciepesRepository : IGenericRepository<Reciepe> 
    
    {
        Task<Reciepe> GetDetails(int id);
    }
}
