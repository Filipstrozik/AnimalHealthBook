namespace AnimalHealthBookApi.Dto
{
    public class HealthNoteEditDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid AnimalId { get; set; }
    }
}
