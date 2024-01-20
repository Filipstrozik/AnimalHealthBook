using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnimalHealthBookApi.Models
{
    public class Vet : User
    {
        public Guid ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }

    }
}
