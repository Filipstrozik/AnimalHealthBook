namespace AnimalHealthBookApi.Models
{
    public class Owner : User
    {
        public string? Address { get; set; }

        public string PhoneNumber { get; set; }


        public string? KennelName { get; set; }

        public virtual IEnumerable<Animal> Animals { get; set; }
    }
}
