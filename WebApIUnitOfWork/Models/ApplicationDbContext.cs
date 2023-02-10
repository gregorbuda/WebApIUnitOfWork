using Microsoft.EntityFrameworkCore;

namespace WebApIUnitOfWork.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Tabla> tabla { get; set; }
    }
}
