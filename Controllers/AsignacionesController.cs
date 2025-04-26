using FutbolPeruano.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FutbolPeruano.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Jugador = new SelectList(_context.Jugador.ToList(), "Id", "Nombre");
            ViewBag.Equipos = new SelectList(_context.Equipos.ToList(), "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Asignaciones asignacion)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    bool jugadorYaAsignado = _context.Asignaciones
                        .Any(a => a.JugadorId == asignacion.JugadorId);

                    if (jugadorYaAsignado)
                    {
                        ModelState.AddModelError("", "Este jugador ya está asignado a un equipo.");
                    }
                    else
                    {
                        _context.Asignaciones.Add(asignacion);
                        _context.SaveChanges();

                        Console.WriteLine("Asignación guardada correctamente.");

                        return RedirectToAction("Listar");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar en la base de datos:");
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", "Ocurrió un error al guardar la asignación.");
                }
            }
            else
            {
                Console.WriteLine("ModelState inválido:");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(" - " + error.ErrorMessage);
                }
            }

            ViewBag.Jugador = new SelectList(_context.Jugador.ToList(), "Id", "Nombre");
            ViewBag.Equipos = new SelectList(_context.Equipos.ToList(), "Id", "Nombre");

            return View(asignacion);
        }

        public IActionResult Listar()
        {
            var lista = _context.Asignaciones
                        .Select(a => new
                        {
                            Jugador = a.Jugador.Nombre,
                            Equipo = a.Equipo.Nombre
                        })
                        .ToList();

            return View(lista);
        }
    }
}
