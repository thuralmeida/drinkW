using Microsoft.EntityFrameworkCore;

namespace drinkW.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        public DbSet<Recipiente> Recipiente { get; set; }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
