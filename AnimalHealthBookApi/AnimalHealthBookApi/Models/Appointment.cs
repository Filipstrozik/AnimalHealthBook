namespace AnimalHealthBookApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int VetId { get; set; }

        public int ClinicId { get; set; }
        public int AnimalId { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public virtual IEnumerable<Procedure> Procedures { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Vet Vet { get; set; }

        public virtual Clinic Clinic { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
