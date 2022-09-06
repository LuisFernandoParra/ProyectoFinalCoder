using EjemploDeClase;
using Microsoft.AspNetCore.Mvc;


namespace EjemploDeClase
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        [HttpGet]
        public List<Venta> GetVentass()
        {

            return VentasHandler.GetVentas();


        }

        [HttpDelete]

        public bool EliminarVenta([FromBody] int id)
        {
            return VentasHandler.BorrarUnaVenta(id);
        }



        [HttpPost]

        public bool InsertarUnaVenta([FromBody] InsertarUnaVenta venta)
        {
            return VentasHandler.InsertarUnaVenta(new Venta
            {
               comentarios = venta.Comentarios
            });
        }


        [HttpPut]

        public bool ModificarUnaVenta([FromBody] SettearUnaVenta venta)
        {
            return VentasHandler.SettearUnaVenta(new Venta
            {
                id_venta = venta.Id,
                comentarios= venta.Comentarios

            });
        }






    }


}