using IntroASPMVC.Models;
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
            ViewData["Categorias"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            ViewData["Estados"] = new SelectList(_context.Estados, "EstadoId", "Nombre");
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(int a)
        {
            return View();
        }
    }
}
