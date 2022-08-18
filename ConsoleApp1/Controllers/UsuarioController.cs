using EjemploDeClase;
using Microsoft.AspNetCore.Mvc;


namespace EjemploDeClase
{
    [namespace MiPrimeraApi2.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class UsuarioController
        {
            [HttpGet(name = "ConseguirUsuarios")]

            public List<Usuario>GetUsuarios()
            {
                return UsuarioHandler.GetUsuarios();
            }


            [HttpGet]
            public bool login(string nombreUsuario, string Contraeña)
            {
                Usuario usuario = UsuarioHandler.GetUsuarioBycontraseña(NombreUsuario, contraseña);
                {
                    if (usuario.nombre == null)
                        return false;
                    else
                        return true;
                }

            }

        }
        
       


    }
}

