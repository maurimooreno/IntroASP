using IntroASPMVC.Models;
using IntroASPMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASPMVC.Controllers
{
    public class TareaController : Controller
    {
        private readonly IntroAspContext _context;

        public TareaController(IntroAspContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tareas = await _context.Tareas
                .Include(t => t.Usuario)
                .Include(t => t.Estado)
                .Include(t => t.Categoria).ToListAsync();

            return View(tareas);
        }

        public IActionResult Crear()
        {
            var usuarios = _context.Usuarios.Select(u => new {
                u.UsuarioId, 
                NombreCompleto= $"{u.Nombre} {u.Apellido}"
            }).ToList();

            ViewData["Categorias"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            ViewData["Estados"] = new SelectList(_context.Estados, "EstadoId", "Nombre");
            ViewData["Usuarios"] = new SelectList(usuarios, "UsuarioId", "NombreCompleto");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(TareaViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var tarea = new Tarea()
                {
                    Descripcion = model.Descripcion,
                    CategoriaId = model.CategoriaId,
                    EstadoId = model.EstadoId,
                    UsuarioId = model.UsuarioId,
                };

                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var usuarios = _context.Usuarios.Select(u => new {
                u.UsuarioId,
                NombreCompleto = $"{u.Nombre} {u.Apellido}"
            }).ToList();

            ViewData["Categorias"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre", model.CategoriaId);
            ViewData["Estados"] = new SelectList(_context.Estados, "EstadoId", "Nombre", model.EstadoId);
            ViewData["Usuarios"] = new SelectList(usuarios, "UsuarioId", "NombreCompleto", model.UsuarioId);
            return View(model);
        }
    }
}
