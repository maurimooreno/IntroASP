using IntroASPMVC.Models;
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
    }
}
