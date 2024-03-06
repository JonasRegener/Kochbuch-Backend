

using Kochbuch_Backend.Contracts;
using Kochbuch_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Kochbuch_Backend.Repository
{
    public class ReciepesRepository : GenericRepository<Reciepe>, IReciepesRepository
    {
        private readonly KochbuchDbContext _context;

        public ReciepesRepository(KochbuchDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Reciepe> GetDetails(int id)
        {
            var response = await _context.Reciepes.Include(q => q.Ingredients).FirstOrDefaultAsync(q => q.Id == id);
            return response;
        }
    }

   
}
