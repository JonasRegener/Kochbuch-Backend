namespace Kochbuch_Backend.Models.Ingredient
{
    public class IngredientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public int ReciepeId { get; set; }

    }
}
