using Microsoft.AspNetCore.Identity;

namespace AnimalHealthBookApi.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
