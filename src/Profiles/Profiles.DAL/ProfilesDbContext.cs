using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;

namespace Profiles.DAL
{
    public class ProfilesDbContext : DbContext
    {
        public ProfilesDbContext(DbContextOptions<ProfilesDbContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            Database.EnsureCreated();
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<ReceptionistEntity> Receptionists { get; set; }
        public DbSet<SpecializationEntity> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecializationEntity>()
                .HasKey(docspec => new { docspec.DoctorId, docspec.SpecificationId });
        }
    }
}
