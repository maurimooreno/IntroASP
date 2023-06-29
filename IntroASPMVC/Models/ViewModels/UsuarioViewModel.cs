using System.ComponentModel.DataAnnotations;

namespace IntroASPMVC.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
