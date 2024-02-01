using System;
using System.Collections.Generic;

namespace Prj_JDOV_MVCBibliotecaApp.Models;

public partial class Libro
{
    public string Isbn { get; set; } = null!;

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public int? AnioPublicacion { get; set; }

    public string? Editorial { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
