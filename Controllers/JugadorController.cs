using Microsoft.AspNetCore.Mvc;
using FutbolPeruano.Models;

namespace FutbolPeruano.Controllers
{
    public class JugadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Jugador jugador)
        {

            if (ModelState.IsValid)
            {
                _context.Jugador.Add(jugador);
                _context.SaveChanges();

                ViewBag.Message = "Jugador registrado correctamente.";
                return View();
            }

            Console.WriteLine("ModelState inválido");
            return View(jugador);
        }
    }
}
