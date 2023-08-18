namespace AnimalHealthBookApi.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime BirthDate { get; set; }

        public string? CoatColor { get; set; }

        public string? CoatType { get; set; }

        public int AnimalTypeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsCastrated { get; set; }

        public string MicrochipNumber { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }

    }
}
