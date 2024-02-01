using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_JDOV_MVCBibliotecaApp.Models;

namespace Prj_JDOV_MVCBibliotecaApp.Controllers
{
    public class ObtenerPrestamosxUsuarioSPController : Controller
    {
        private readonly BdJdovLaboratorio2Context _context;

        public ObtenerPrestamosxUsuarioSPController(BdJdovLaboratorio2Context context)
        {
            _context = context;
        }
        public List<ObtenerPrestamosxUsuario>GetObtenerPrestamosxUsuarios()
        {
            string sql = "EXEC ObtenerPrestamosxUsuario";
            var result=_context.PrestamosxUsuarios.FromSqlRaw<ObtenerPrestamosxUsuario>(sql);
            return result.ToList();
        }
        public IActionResult Index()
        {
            var result=GetObtenerPrestamosxUsuarios();
            return View(result);
        }
    }
}
