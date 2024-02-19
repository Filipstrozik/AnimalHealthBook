using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalHealthBookApi.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AnimalTypeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }

        public Guid BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public int AnimalGenderId { get; set; }

        public virtual Gender AnimalGender { get; set; }

        public DateTime BirthDate { get; set; }
        
        public Guid CoatColorId { get; set; }
        public CoatColor CoatColor { get; set; }

        public Guid CoatTypeId { get; set; }
        public CoatType CoatType { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

        public bool IsCastrated { get; set; }

        public string? MicrochipNumber { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }

        public virtual IEnumerable<HealthNote> HealthNotes { get; set; }

        public Guid? ProfileImageId { get; set; }

        [ForeignKey("ProfileImageId")]
        public UploadFile? ProfileImage { get; set; }

        public Guid? MainImageId { get; set; }

        [ForeignKey("MainImageId")]
        public UploadFile? MainImage { get; set; }

    }
}
