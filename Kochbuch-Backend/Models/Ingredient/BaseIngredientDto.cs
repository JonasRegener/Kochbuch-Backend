using System.ComponentModel.DataAnnotations;

namespace Kochbuch_Backend.Models.Ingredient
{
    public abstract class BaseIngredientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }

        public int ReciepeId { get; set; }

    }

    
}
