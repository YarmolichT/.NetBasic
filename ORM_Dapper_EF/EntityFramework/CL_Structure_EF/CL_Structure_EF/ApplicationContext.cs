using Microsoft.EntityFrameworkCore;

namespace CL_Structure_EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Product { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>()
                .Property(a => a.Orderd_Id)
                .IsRequired();

            modelBuilder.Entity<ProductModel>()
                .Property(a => a.Product_Id)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SQL_Project;Integrated Security=True");
        }
    }
}
