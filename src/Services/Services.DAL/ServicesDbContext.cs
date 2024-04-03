using Microsoft.EntityFrameworkCore;
using Services.DAL.Entities;

namespace Services.DAL
{
    public class ServicesDbContext : DbContext
    {
        public ServicesDbContext(DbContextOptions<ServicesDbContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            Database.EnsureCreated();
        }

        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<ServiceCategoryEntity> ServiceCategories { get; set; }
    }
}
