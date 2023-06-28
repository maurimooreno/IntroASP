using System;
using System.Collections.Generic;

namespace IntroASPMVC.Models;

public partial class Tarea
{
    public int TareaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? EstadoId { get; set; }

    public int? CategoriaId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
