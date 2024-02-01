using System;
using System.Collections.Generic;

namespace Prj_JDOV_MVCBibliotecaApp.Models;

public partial class Prestamo
{
    public int Idprestamo { get; set; }

    public string? Isbn { get; set; }

    public int Idusuario { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Libro? IsbnNavigation { get; set; }
}
