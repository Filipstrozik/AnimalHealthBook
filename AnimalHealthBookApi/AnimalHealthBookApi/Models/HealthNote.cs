namespace AnimalHealthBookApi.Models
{
    public class HealthNote
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
