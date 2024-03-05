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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            System.Diagnostics.Debug.WriteLine(_configuration);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one (Office - Photo)
            modelBuilder.Entity<OfficeEntity>()
                .HasOne(off => off.Photo)
                .WithOne()
                .HasForeignKey<PhotoEntity>(ph => ph.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-one (Account - Photo)
            modelBuilder.Entity<AccountEntity>()
                .HasOne(acc => acc.Photo)
                .WithOne()
                .HasForeignKey<PhotoEntity>(ph => ph.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-one (Receptionist - Account)
            modelBuilder.Entity<ReceptionistEntity>()
                .HasOne(rec => rec.Account)
                .WithOne()
                .HasForeignKey<AccountEntity>(acc => acc.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-one (Receptionist - Office)
            modelBuilder.Entity<ReceptionistEntity>()
                .HasOne(rec => rec.Office)
                .WithOne()
                .HasForeignKey<OfficeEntity>(off => off.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-one (Patient - Account)
            modelBuilder.Entity<PatientEntity>()
                .HasOne(pat => pat.Account)
                .WithOne()
                .HasForeignKey<AccountEntity>(acc => acc.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-many (Pacient - Appointment)
            modelBuilder.Entity<PatientEntity>()
                .HasMany(pat => pat.Appointments)
                .WithOne(app => app.Patient)
                .HasForeignKey(app => app.PatientId)
                .HasPrincipalKey(pat => pat.Id);

            //one-to-one (Doctor - Account)
            modelBuilder.Entity<DoctorEntity>()
                .HasOne(doc => doc.Account)
                .WithOne()
                .HasForeignKey<AccountEntity>(acc => acc.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //many-to-one (Doctor - Office)
            modelBuilder.Entity<DoctorEntity>()
                .HasOne(doc => doc.Office)
                .WithMany(off => off.Doctors)
                .HasForeignKey(doc => doc.OfficeId)
                .HasPrincipalKey(off => off.Id);

            //one-to-many (Doctor - Appointment)
            modelBuilder.Entity<DoctorEntity>()
                .HasMany(doc => doc.Appointments)
                .WithOne(app => app.Doctor)
                .HasForeignKey(app => app.DoctorId)
                .HasPrincipalKey(doc => doc.Id);

            //one-to-many (Doctor - Appointment)
            modelBuilder.Entity<DoctorEntity>()
                .HasMany(doc => doc.Specializations)
                .WithOne()
                .HasForeignKey(spec => spec.Id);

            //one-to-one (Document - Result)
            modelBuilder.Entity<DocumentEntity>()
                .HasOne(doc => doc.Result)
                .WithOne()
                .HasForeignKey<ResultEntity>(res => res.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-one (Result - Appointment)
            modelBuilder.Entity<ResultEntity>()
                .HasOne(res => res.Appointment)
                .WithOne()
                .HasForeignKey<AppointmentEntity>(app => app.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //one-to-many (Service - Appointment)
            modelBuilder.Entity<ServiceEntity>()
                .HasMany(srv => srv.Appointments)
                .WithOne(app => app.Service)
                .HasForeignKey(app => app.ServiceId)
                .HasPrincipalKey(srv => srv.Id);

            //one-to-many (Service - ServiceCategory)
            modelBuilder.Entity<ServiceEntity>()
                .HasOne(srv => srv.Category)
                .WithMany()
                .HasPrincipalKey(srvcat => srvcat.Id);
        }
    }
}
