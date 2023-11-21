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

    }
}
