using Microsoft.AspNetCore.Mvc;
using PostSeguridadPersonalizada.Filters;
using PostSeguridadPersonalizada.Models;
using PostSeguridadPersonalizada.Repositories;

namespace PostSeguridadPersonalizada.Controllers
{
    public class DeportesController : Controller
    {
        private RepositoryDeportes repo;
        public DeportesController(RepositoryDeportes repo)
        {
            this.repo = repo;
        }

        public async Task <IActionResult> Deportes()
        {
            List<DetalleDeporte>deportes = await this.repo.GetDeportesAsync();
            return View(deportes);
        }

        [AuthorizeUsers]
        public async Task<IActionResult> DetailDeporte(int id)
        {
            DetalleDeporte deporte  = await this.repo.FindDeporteById(id);
            return View(deporte);
        }

        [AuthorizeUsers]
        public async Task< IActionResult> Perfil()
        {
            return View();
        }
    }
}
