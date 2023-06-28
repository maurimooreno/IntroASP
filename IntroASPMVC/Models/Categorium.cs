using System;
using System.Collections.Generic;

namespace IntroASPMVC.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
