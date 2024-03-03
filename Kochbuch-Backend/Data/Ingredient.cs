using System.ComponentModel.DataAnnotations.Schema;

namespace Kochbuch_Backend.Data
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }

        [ForeignKey(nameof(ReciepeId))]
        public int ReciepeId { get; set; }

        public Reciepe Reciepe { get; set; }
    }
}
