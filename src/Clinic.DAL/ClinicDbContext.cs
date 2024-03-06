using Clinic.DAL.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Numerics;

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
                .HasPrincipalKey<PhotoEntity>(ph => ph.Id)
                .HasForeignKey<OfficeEntity>(off => off.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Account - Photo)
            modelBuilder.Entity<AccountEntity>()
                .HasOne(acc => acc.Photo)
                .WithOne()
                .HasPrincipalKey<PhotoEntity>(ph => ph.Id)
                .HasForeignKey<AccountEntity>(acc => acc.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Receptionist - Account)
            modelBuilder.Entity<ReceptionistEntity>()
                .HasOne(rec => rec.Account)
                .WithOne()
                .HasPrincipalKey<AccountEntity>(acc => acc.Id)
                .HasForeignKey<ReceptionistEntity>(rep => rep.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Receptionist - Office) no cascade
            modelBuilder.Entity<ReceptionistEntity>()
                .HasOne(rec => rec.Office)
                .WithOne()
                .HasPrincipalKey<OfficeEntity>(off => off.Id)
                .HasForeignKey<ReceptionistEntity>(rep => rep.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Patient - Account) no cascade
            modelBuilder.Entity<PatientEntity>()
                .HasOne(pat => pat.Account)
                .WithOne()
                .HasPrincipalKey<AccountEntity>(acc => acc.Id)
                .HasForeignKey<PatientEntity>(pat => pat.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-many (Pacient - Appointment)
            modelBuilder.Entity<PatientEntity>()
                .HasMany(pat => pat.Appointments)
                .WithOne(app => app.Patient)
                .HasForeignKey(app => app.PatientId)
                .HasPrincipalKey(pat => pat.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Doctor - Account) no cascade
            modelBuilder.Entity<DoctorEntity>()
                .HasOne(doc => doc.Account)
                .WithOne()
                .HasPrincipalKey<AccountEntity>(acc => acc.Id)
                .HasForeignKey<DoctorEntity>(doc => doc.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-many (Doctor - Office)
            modelBuilder.Entity<DoctorEntity>()
                .HasOne(doc => doc.Office)
                .WithMany(off => off.Doctors)
                .HasForeignKey(doc => doc.OfficeId)
                .HasPrincipalKey(off => off.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-many (Doctor - Appointment)
            modelBuilder.Entity<DoctorEntity>()
                .HasMany(doc => doc.Appointments)
                .WithOne(app => app.Doctor)
                .HasForeignKey(app => app.DoctorId)
                .HasPrincipalKey(doc => doc.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Document - Result)
            modelBuilder.Entity<DocumentEntity>()
                .HasOne(doc => doc.Result)
                .WithOne()
                .HasPrincipalKey<ResultEntity>(res => res.Id)
                .HasForeignKey<DocumentEntity>(doc => doc.ResultId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-one (Result - Appointment)
            modelBuilder.Entity<ResultEntity>()
                .HasOne(res => res.Appointment)
                .WithOne()
                .HasPrincipalKey<ResultEntity>(res => res.Id)
                .HasForeignKey<ResultEntity>(res => res.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-many (Service - Appointment)
            modelBuilder.Entity<ServiceEntity>()
                .HasMany(srv => srv.Appointments)
                .WithOne(app => app.Service)
                .HasForeignKey(app => app.ServiceId)
                .HasPrincipalKey(srv => srv.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //one-to-many (Service - ServiceCategory)
            modelBuilder.Entity<ServiceEntity>()
                .HasOne(srv => srv.Category)
                .WithMany()
                .HasPrincipalKey(srvcat => srvcat.Id)
                .HasForeignKey(srv => srv.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //many-to-many(Doctor - Specialization)
            modelBuilder.Entity<DoctorSpecializationEntity>()
                .HasKey(docspec => new { docspec.DoctorId, docspec.SpecificationId });
        }
    }
}
