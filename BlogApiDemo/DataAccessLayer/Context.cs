using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogDb;integrated security=true");

            //optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogDb;User Id=sa;Password=1234;TrustServerCertificate=true");

            optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogApiDb; Trusted_Connection=True;TrustServerCertificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
