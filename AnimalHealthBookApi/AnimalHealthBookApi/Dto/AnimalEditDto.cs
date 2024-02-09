using AnimalHealthBookApi.Models;

namespace AnimalHealthBookApi.Dto
{
    public class AnimalEditDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid BreedId { get; set; }

        public int AnimalGenderId { get; set; }

        public DateTime BirthDate { get; set; }

        public string? CoatColor { get; set; }

        public string? CoatType { get; set; }

        public Guid AnimalTypeId { get; set; }

        public IEnumerable<User> Users { get; set; }

        public bool IsCastrated { get; set; }

        public string? MicrochipNumber { get; set; }
    }
}
