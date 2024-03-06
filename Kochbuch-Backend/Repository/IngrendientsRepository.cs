using Kochbuch_Backend.Contracts;
using Kochbuch_Backend.Data;

namespace Kochbuch_Backend.Repository
{
    public class IngrendientsRepository : GenericRepository<Ingredient>, IIngredientsRepository
    {
        public IngrendientsRepository(KochbuchDbContext context) : base(context)
        {
        }
    }
}
