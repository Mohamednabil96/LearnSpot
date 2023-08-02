using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskDay2.Models
{
    public class MyDbContext : DbContext
    {
   
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }
        public DbSet <Account> Account { get; set; }

        public MyDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Data Source=localhost; Initial Catalog=MVCTaskDay2; Integrated Security=True; TrustServerCertificate=True; Encrypt=False");
        }

    }
}
