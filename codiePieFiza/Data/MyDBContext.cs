using codiePieFiza.Models;
using Microsoft.EntityFrameworkCore;

namespace codiePieFiza.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }

        public DbSet<Register> Register { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }

    }
}
