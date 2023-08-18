namespace AnimalHealthBookApi.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public string? LotNumber { get; set; }

        public int ProcedureId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Procedure Procedure { get; set; }
    }
}
