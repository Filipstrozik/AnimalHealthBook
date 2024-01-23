using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Context
{
    public class AHBContext : IdentityDbContext<User, Role, Guid>
    {

        public AHBContext(DbContextOptions<AHBContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Medicine> Medicines { get; set; }


        public DbSet<AnimalHealthBookApi.Models.Vet>? Vet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Procedures)
                .WithOne(p => p.Appointment)
                .HasForeignKey(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Clinic)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Animal)
                .WithMany(an => an.Appointments)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.AnimalType);

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Appointments)
                .WithOne(a => a.Animal)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vet>()
                .HasMany(v => v.Appointments)
                .WithOne(a => a.Vet)
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vet>()
                .HasOne(v => v.Clinic)
                .WithMany(c => c.Vets)
                .HasForeignKey(v => v.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Procedure>()
                .HasMany(p => p.Medicines)
                .WithOne(m => m.Procedure)
                .HasForeignKey(m => m.ProcedureId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Clinic)
                .HasForeignKey(a => a.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }


        public DbSet<AnimalHealthBookApi.Models.Owner>? Owner { get; set; }


        public DbSet<AnimalHealthBookApi.Models.Breeder>? Breeder { get; set; }



    }
}
