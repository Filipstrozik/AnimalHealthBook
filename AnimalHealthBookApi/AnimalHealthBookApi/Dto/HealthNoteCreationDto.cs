namespace AnimalHealthBookApi.Dto
{
    public class HealthNoteCreationDto
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid AnimalId { get; set; }
    }
}
