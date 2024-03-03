namespace Kochbuch_Backend.Models.Reciepe
{
    public abstract class BaseReciepeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int DurationMinutes { get; set; } = 0;
    }
}
