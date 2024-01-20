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
                new Role {Id = new Guid("ebda0a56-6ddb-447d-ae99-58e4e296a57b"), Name = "Owner" },
                new Role {Id = new Guid("8ec62275-90dc-4340-99c6-5f983a83ddfb"), Name = "Breeder" },
                new Role {Id = new Guid("39a39cd5-f6f3-4293-b95a-7ac5db398148"), Name = "Vet" }
            };
        }

        private IEnumerable<Clinic> GetClinics()
        {
            return new Clinic[]
            {
                new Clinic {Id=new Guid("1e6e1e40-3411-4575-9daf-181d1ea70cd9") ,Name = "Klinika Dr HAU", Description="opis", Email="dr.hau@wp.pl", PhoneNumber="987654321" },
                new Clinic {Id=new Guid("49377882-cd2b-4cbc-8193-673f56673a9e") ,Name = "Klinka szybka", Description="2", Email="szybka@wp.pl", PhoneNumber="123456789"},
            };
        }

        private IEnumerable<User> GetUsers()
        {
            return new User[]
            {
                new User { Id=new Guid("2443c60e-4076-4208-becf-e254c19268a1"), Name = "Jan", Email="jan.nowak@wp.pl", Lastname="Nowak", RoleId=new Guid("ebda0a56-6ddb-447d-ae99-58e4e296a57b") , PasswordHash="test1" },
                new Vet { Id=new Guid("210d9643-56e0-407b-ba86-3778205bd93b"), Name = "Jakub", Email="kuba.waran@wp.pl", Lastname="Waran", RoleId=new Guid("39a39cd5-f6f3-4293-b95a-7ac5db398148") , PasswordHash="test2", Description="Jestem wterynarzem", ClinicId=new Guid("1e6e1e40-3411-4575-9daf-181d1ea70cd9")},
            };
        }

        private IEnumerable<AnimalType> GetAnimalTypes()
        {
            return new AnimalType[]
            {
                new AnimalType {Id=new Guid("2443c60e-4076-4208-becf-e254c19268a2"), Name="Dog"},
                new AnimalType {Id=new Guid("2443c60e-4076-4208-becf-e254c19268a3"), Name="Cat"},
            };
        }

        private IEnumerable<Animal> GetAnimals()
        {
            return new Animal[]
            {
                new Animal { 
                    Name="Benek", 
                    AnimalTypeId=new Guid("2443c60e-4076-4208-becf-e254c19268a2"), 
                    UserId = new Guid("2443c60e-4076-4208-becf-e254c19268a1"),
                    BirthDate = new DateTime(2022, 3, 15),
                    Breed = "Boston Terrier",
                    CoatColor = "Black - White",
                    CoatType = "Short",
                    IsCastrated = false,
                    MicrochipNumber = "123456789012345"
                },
                new Animal { 
                    Name="Sofia",
                    AnimalTypeId=new Guid("2443c60e-4076-4208-becf-e254c19268a3"),
                    UserId = new Guid("d105e465-0426-49c4-980e-fdfe2eac2478"),
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
