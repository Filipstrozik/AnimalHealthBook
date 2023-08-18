namespace AnimalHealthBookApi.Models
{
    public class Owner : User
    {
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual IEnumerable<Animal> Animals { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }
    }
}
