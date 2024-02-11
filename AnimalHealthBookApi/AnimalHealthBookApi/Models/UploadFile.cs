using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalHealthBookApi.Models
{
    public class UploadFile
    {
        
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string? Path { get; set; }
    }   
}
