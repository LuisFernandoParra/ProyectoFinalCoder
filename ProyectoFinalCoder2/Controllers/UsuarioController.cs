using EjemploDeClase;
using Microsoft.AspNetCore.Mvc;


namespace EjemploDeClase
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios([FromBody]string NombreUsuario)
        {
            return UsuarioHandler.ObtenerUsuariosPorNombreDeUsuario(NombreUsuario);
        }

        [HttpDelete]

        public bool EliminarUsuarios([FromBody] int id)
        {
         return UsuarioHandler.BorrarUnUsuario(id);
        }



        [HttpPost]
        
        public bool InsertarUsuario([FromBody]  CrearUnUsuario usuario)
        {
            return UsuarioHandler.InsertarUnUsuario(new Usuario
            {
                nombre = usuario.Nombre,
                apellido = usuario.Apellido,
                mail = usuario.Mail,
                nombre_usuario = usuario.NombreUsuario,
                contrasena = usuario.Contraseña,




            });
        }


        [HttpPut]

        public bool ModificarUnUsuario([FromBody] SettearUnUsuario usuario)
        {
            return UsuarioHandler.SettearUnUsuario(new Usuario
            {
                id = usuario.Id,
                apellido = usuario.Apellido,
                mail = usuario.Mail,
                nombre_usuario = usuario.NombreUsuario,
            });
        }

        [HttpGet("Login")]
        public Usuario Login(string NombreUsuario,string Contraseña)
        {
            return new Usuario();
        }




    }


}
