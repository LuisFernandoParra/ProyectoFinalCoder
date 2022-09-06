using Microsoft.AspNetCore.Mvc;
namespace EjemploDeClase
{
    [ApiController]
    [Route("[controller]")]
    public class NombreController : ControllerBase
    {
        [HttpGet]
        public static string  Nombre()
        {

            return NombreApp.ObtenerNombreApp();


        }
    }
}