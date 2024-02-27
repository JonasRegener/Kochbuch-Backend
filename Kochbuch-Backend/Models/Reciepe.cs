namespace Kochbuch_Backend.Models
{
    public class Reciepe
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public int DurationMinutes { get; set; } 
         
    }
}
