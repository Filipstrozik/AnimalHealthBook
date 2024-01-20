using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public Guid VetId { get; set; }

        public Guid ClinicId { get; set; }
        public Guid AnimalId { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public virtual IEnumerable<Procedure> Procedures { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]

        public virtual Vet Vet { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Clinic Clinic { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]

        public virtual Animal Animal { get; set; }
    }
}
