using Kochbuch_Backend.Models.Ingredient;

namespace Kochbuch_Backend.Models.Reciepe
{
    public class ReciepeDetailsDto : BaseReciepeDto
    {
        public int Id { get; set; }

        public List<IngredientDto> Ingredients { get; set; }

        public int DurationMinutes { get; set; }

        public string ImagePath { get; set; }

    }
}
