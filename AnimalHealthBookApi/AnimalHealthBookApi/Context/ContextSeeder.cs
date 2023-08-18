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
            if (!_context.Roles.Any())
            {
                var roles = GetRoles();
                _context.AddRange(roles);
                _context.SaveChanges();
            }

            if (!_context.Clinics.Any())
            {
                var clinics = GetClinics();
                _context.AddRange(clinics);
                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                var users = GetUsers();
                _context.AddRange(users);
                _context.SaveChanges();
            }

            if (!_context.AnimalTypes.Any())
            {
                var animalTypes = GetAnimalTypes();
                _context.AddRange(animalTypes);
                _context.SaveChanges();
            }

            if (!_context.Animals.Any())
            {
                var animals = GetAnimals();
                _context.AddRange(animals);
                _context.SaveChanges();
            }


        }

        private IEnumerable<Role> GetRoles()
        {
            return new Role[]
            {
                new Role { Name = "Owner" },
                new Role { Name = "Breeder" },
                new Role { Name = "Vet" }
            };
        }

        private IEnumerable<Clinic> GetClinics()
        {
            return new Clinic[]
            {
                new Clinic { Name = "Klinika Dr HAU", Description="opis", Email="dr.hau@wp.pl", PhoneNumber="987654321" },
                new Clinic { Name = "Klinka szybka", Description="2", Email="szybka@wp.pl", PhoneNumber="123456789"},
            };
        }

        private IEnumerable<User> GetUsers()
        {
            return new User[]
            {
                new User { Name = "Jan", Email="jan.nowak@wp.pl", Surname="Nowak", RoleId=2 , PasswordHash="test1" },
                new Vet { Name = "Jakub", Email="kuba.waran@wp.pl", Surname="Waran", RoleId=3 , PasswordHash="test2", Description="Jestem wterynarzem", ClinicId=1},
            };
        }

        private IEnumerable<AnimalType> GetAnimalTypes()
        {
            return new AnimalType[]
            {
                new AnimalType { Name="Dog"},
                new AnimalType { Name="Cat"},
            };
        }

        private IEnumerable<Animal> GetAnimals()
        {
            return new Animal[]
            {
                new Animal { 
                    Name="Benek", 
                    AnimalTypeId=1, 
                    UserId = 1,
                    BirthDate = new DateTime(2022, 3, 15),
                    Breed = "Boston Terrier",
                    CoatColor = "Black - White",
                    CoatType = "Short",
                    IsCastrated = false,
                    MicrochipNumber = "123456789012345"
                },
                new Animal { 
                    Name="Sofia",
                    AnimalTypeId=2,
                    UserId = 1,
                    BirthDate = new DateTime(2022, 3, 15),
                    Breed = "Ragdoll",
                    CoatColor = "White",
                    CoatType = "Long",
                    IsCastrated = false,
                    MicrochipNumber = "123456789011231"
                },
            };
        }
    }
}
