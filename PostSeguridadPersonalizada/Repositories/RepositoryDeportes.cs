using Microsoft.EntityFrameworkCore;
using PostSeguridadPersonalizada.Data;
using PostSeguridadPersonalizada.Models;

namespace PostSeguridadPersonalizada.Repositories
{
    public class RepositoryDeportes
    {
        private DeportesContext context;
        public RepositoryDeportes(DeportesContext context)
        {
            this.context = context;
        }

        //GET todos los deportes 
        public async Task<List<DetalleDeporte>> GetDeportesAsync()
        {
            return  await this.context.DetalleDeporte.ToListAsync();
        }

        //Find Deporte por id 
        public async Task<DetalleDeporte> FindDeporteById(int id)
        {
            return await context.DetalleDeporte.FirstOrDefaultAsync(p => p.IdDetalle == id);
        }
    }
}
