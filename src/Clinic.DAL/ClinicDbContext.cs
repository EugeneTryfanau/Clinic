using Clinic.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Clinic.DAL
{
    public class ClinicDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options, IConfiguration configuration) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            _configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<ReceptionistEntity> Receptionists { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<ResultEntity> Results { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<ServiceCategoryEntity> ServiceCategories { get; set; }
        public DbSet<SpecializationEntity> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecializationEntity>()
                .HasKey(docspec => new { docspec.DoctorId, docspec.SpecificationId });
        }
    }
}
