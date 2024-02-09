namespace AnimalHealthBookApi.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AnimalTypeId { get; set; }

        public virtual Breed Breed { get; set; }

        public int AnimalGenderId { get; set; }

        public virtual Gender AnimalGender { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string? CoatColor { get; set; }

        public string? CoatType { get; set; }

        public Guid AnimalTypeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

        public bool IsCastrated { get; set; }

        public string? MicrochipNumber { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }

        public virtual IEnumerable<HealthNote> HealthNotes { get; set; }

    }
}
