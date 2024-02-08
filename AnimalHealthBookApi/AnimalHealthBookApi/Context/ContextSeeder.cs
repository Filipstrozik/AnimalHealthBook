using AnimalHealthBookApi.Models;

namespace AnimalHealthBookApi.Context
{
    public class ContextSeeder
    {
        private readonly AHBContext _context;

        public ContextSeeder(AHBContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            _context.Database.EnsureCreated();
            
                AnimalType dog = _context.AnimalTypes.Where(a => a.Name == "Dog").FirstOrDefault();
                AnimalType cat = new AnimalType { Name = "Cat" };
                AnimalType horse = new AnimalType { Name = "Horse" };
                AnimalType bird = new AnimalType { Name = "Bird" };
                AnimalType fish = new AnimalType { Name = "Fish" };
                AnimalType reptile = new AnimalType { Name = "Reptile" };

                _context.AnimalTypes.AddRange(cat, horse, bird, fish, reptile);


                Breed bostonTerrier = new Breed { Name = "Boston Terrier", AnimalType = dog };
                _context.Breeds.Add(bostonTerrier);

                Breed germanShepherd = new Breed { Name = "German Shepherd", AnimalType = dog };
                _context.Breeds.Add(germanShepherd);

                Breed labrador = new Breed { Name = "Labrador", AnimalType = dog };
                _context.Breeds.Add(labrador);

                Breed siamese = new Breed { Name = "Siamese", AnimalType = cat };
                _context.Breeds.Add(siamese);

                Breed persian = new Breed { Name = "Persian", AnimalType = cat };
                _context.Breeds.Add(persian);

                Breed thoroughbred = new Breed { Name = "Thoroughbred", AnimalType = horse };
                _context.Breeds.Add(thoroughbred);

                Breed quarterHorse = new Breed { Name = "Quarter Horse", AnimalType = horse };
                _context.Breeds.Add(quarterHorse);

                Breed parakeet = new Breed { Name = "Parakeet", AnimalType = bird };
                _context.Breeds.Add(parakeet);

                Breed canary = new Breed { Name = "Canary", AnimalType = bird };
                _context.Breeds.Add(canary);

                Breed goldfish = new Breed { Name = "Goldfish", AnimalType = fish };
                _context.Breeds.Add(goldfish);

                Breed betta = new Breed { Name = "Betta", AnimalType = fish };
                _context.Breeds.Add(betta);

                Breed iguana = new Breed { Name = "Iguana", AnimalType = reptile };
                _context.Breeds.Add(iguana);

                Breed python = new Breed { Name = "Python", AnimalType = reptile };
                _context.Breeds.Add(python);




                _context.SaveChanges();
           

        }
    }
}
