using System.ComponentModel.DataAnnotations;

namespace Kochbuch_Backend.Models.Ingredient
{
    public abstract class BaseIngredientDto
    {
        [Required]
        public string Name { get; set; }

        public int ReciepeId { get; set; }

        public int Quantity { get; set; } 

        public string Measurement { get; set; } 


    }

    
}
