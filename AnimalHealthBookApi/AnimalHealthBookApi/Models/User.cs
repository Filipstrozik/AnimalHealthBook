using System.ComponentModel.DataAnnotations;

namespace AnimalHealthBookApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}
