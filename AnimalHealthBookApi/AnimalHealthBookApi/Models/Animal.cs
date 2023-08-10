namespace AnimalHealthBookApi.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AnimalTypeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
