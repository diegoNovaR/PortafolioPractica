using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolioUdemy.Models;

namespace portafolioUdemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proyectos = ObtenerProyecto().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }


        private List<ProyectoDTO> ObtenerProyecto()
        {
            return new List<ProyectoDTO>()
            {
                new ProyectoDTO
                {
                    Titulo = "Amazon",
                    Descripcion = "Ecommerce realizado en ASP.NET CORE",
                    Link = "https://www.amazon.com",
                    ImagenURL = "/imagenes/amazon.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Netflix",
                    Descripcion = "Plataforma de streaming de series y películas",
                    Link = "https://www.netflix.com/",
                    ImagenURL = "/imagenes/netflix.jpg"
                },
                new ProyectoDTO
                {
                    Titulo = "Spotify",
                    Descripcion = "Servicio de música en streaming",
                    Link = "https://www.spotify.com/",
                    ImagenURL = "/imagenes/spotify.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Steam",
                    Descripcion = "Plataforma de videos en línea",
                    Link = "https://store.steampowered.com/",
                    ImagenURL = "/imagenes/steam.jpg" 
                }
            };
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
