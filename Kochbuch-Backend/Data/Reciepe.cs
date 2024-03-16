using System.ComponentModel.DataAnnotations.Schema;

namespace Kochbuch_Backend.Data
{
    public class Reciepe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; } = 0;

        public virtual IList<Ingredient> Ingredients { get; set; }

        public string ImagePath { get; set; }

    }
}
