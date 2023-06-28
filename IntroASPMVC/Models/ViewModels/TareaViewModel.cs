using System.ComponentModel.DataAnnotations;

namespace IntroASPMVC.Models.ViewModels
{
    public class TareaViewModel
    {
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
    }
}
