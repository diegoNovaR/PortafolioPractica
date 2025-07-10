using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolioUdemy.Models;
using portafolioUdemy.Servicios;

namespace portafolioUdemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repo;//principios de inversi[on de dependencias
        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            
            var proyectos = repo.ObtenerProyecto().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }



        public IActionResult Proyectos()
        {
            var proyectos = repo.ObtenerProyecto().ToList();
            
            return View(proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
