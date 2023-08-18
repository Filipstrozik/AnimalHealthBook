namespace AnimalHealthBookApi.Models
{
    public class Clinic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Vet> Vets { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }
    }
}
