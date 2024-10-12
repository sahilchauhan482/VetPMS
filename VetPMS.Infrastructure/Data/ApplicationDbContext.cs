using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetPMS.Domain.Entities;

namespace VetPMS.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Clinic)
                .WithMany(c => c.Owners)
                .HasForeignKey(o => o.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Breed>()
       .HasOne(b => b.Clinic)
       .WithMany(c => c.Breeds)
       .HasForeignKey(b => b.ClinicId)
       .OnDelete(DeleteBehavior.Restrict);
        }
    }




}
