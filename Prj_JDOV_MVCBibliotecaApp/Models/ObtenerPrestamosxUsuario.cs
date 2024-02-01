using Microsoft.EntityFrameworkCore;

namespace Prj_JDOV_MVCBibliotecaApp.Models
{
    [Keyless]
    public partial class ObtenerPrestamosxUsuario
    {
        public int Id { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Isbn { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Editorial { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
