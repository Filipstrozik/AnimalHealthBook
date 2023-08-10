using AnimalHealthBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Context
{
    public class AHBContext : DbContext
    {
        public AHBContext(DbContextOptions<AHBContext> options)
            : base(options)
        {
            
        }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }



        public DbSet<AnimalHealthBookApi.Models.Vet>? Vet { get; set; }



        public DbSet<AnimalHealthBookApi.Models.Clinic>? Clinic { get; set; }
    }
}
