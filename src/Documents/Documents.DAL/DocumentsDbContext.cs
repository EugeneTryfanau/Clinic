using Documents.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Documents.DAL
{
    public class DocumentsDbContext : DbContext
    {
        public DocumentsDbContext(DbContextOptions<DocumentsDbContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            Database.EnsureCreated();
        }

        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
    }
}
