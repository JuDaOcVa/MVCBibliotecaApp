using Microsoft.AspNetCore.Mvc;
using Prj_JDOV_MVCBibliotecaApp.Models;

namespace Prj_JDOV_MVCBibliotecaApp.Controllers
{
    public class ObtenerPrestamosxUsuarioController : Controller
    {
        private readonly BdJdovLaboratorio2Context _context;

        public ObtenerPrestamosxUsuarioController(BdJdovLaboratorio2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var query = (from p in _context.Prestamos
                         join u in _context.Usuarios on p.Idusuario equals u.Idusuario
                         join l in _context.Libros on p.Isbn equals l.Isbn
                         select new Models.ObtenerPrestamosxUsuario
                         {
                             Isbn = p.Isbn,
                             Titulo= l.Titulo,
                             FechaPrestamo = p.FechaPrestamo,
                             FechaDevolucion = p.FechaDevolucion,
                             Nombre = u.Nombre,
                             Apellido = u.Apellido
                         });
            return base.View(query.ToList<Models.ObtenerPrestamosxUsuario>());
        }
    }
}
