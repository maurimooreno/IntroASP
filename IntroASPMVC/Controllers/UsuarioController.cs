using IntroASPMVC.Models;
using IntroASPMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASPMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IntroAspContext _context;

        public UsuarioController(IntroAspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuario(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Correo == model.Correo);
                if (usuarioExiste)
                {
                    ModelState.AddModelError("Correo", "Ya existe un usuario con este correo electronico");
                    return View(model);
                }

                var newUSer = new Usuario()
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                };
                _context.Add(newUSer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
