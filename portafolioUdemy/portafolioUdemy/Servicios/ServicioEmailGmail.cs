using System.Net;
using System.Net.Mail;
using portafolioUdemy.Models;

namespace portafolioUdemy.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoDTO contactoDTO);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoDTO contactoDTO)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL: EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL: PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL: HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL: PUERTO");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor, emailEmisor,
                $"El cliente {contactoDTO.Nombre} ({contactoDTO.Email}) quiere Contactarte", contactoDTO.Mensaje);
            await smtpCliente.SendMailAsync(mensaje);
        }

    }
}
