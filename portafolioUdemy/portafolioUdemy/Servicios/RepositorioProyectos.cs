using portafolioUdemy.Models;

namespace portafolioUdemy.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyecto();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {

        public List<ProyectoDTO> ObtenerProyecto()
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

    }
}
