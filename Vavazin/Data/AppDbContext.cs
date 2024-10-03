using Microsoft.EntityFrameworkCore;
using Vavazin.Models;

namespace Vavazin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Vavazin.Models.Anuncio> Anuncios { get; set; }
    }
}
