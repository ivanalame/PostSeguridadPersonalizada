using Microsoft.EntityFrameworkCore;
using PostSeguridadPersonalizada.Models;

namespace PostSeguridadPersonalizada.Data
{
    public class DeportesContext: DbContext
    {
        public DeportesContext(DbContextOptions<DeportesContext>options):base (options) { }

        public DbSet<DetalleDeporte> DetalleDeporte { get; set; }
    }
}
