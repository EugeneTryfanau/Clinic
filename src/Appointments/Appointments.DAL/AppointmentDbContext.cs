using Appointments.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointments.DAL
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            Database.EnsureCreated();
        }

        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<ResultEntity> Results { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
    }
}
