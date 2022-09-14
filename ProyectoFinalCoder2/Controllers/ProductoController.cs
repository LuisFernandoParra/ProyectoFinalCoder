using EjemploDeClase;
using Microsoft.AspNetCore.Mvc;


namespace EjemploDeClase
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public List<Producto> GetProductos()
        {

            return productoHandler.ObtenerProductos();  
        
                
        }

        [HttpDelete]

        public bool EliminarProducto([FromBody] int id)
        {
            return productoHandler.BorrarUnProducto(id);
        }



        [HttpPost]

        public bool InsertarUnProducto([FromBody] CrearUnProducto producto)
        {
            return productoHandler.InsertarUnProducto(new Producto
            {
              IdUsuario = producto.id_usuario,
              Descripcion = producto.descripcion,
              Costo = producto.costo,
              Stock = producto.stock,
              PrecioDeVenta = producto.precio_de_venta,
             

            });
        }


        [HttpPut]

        public bool ModificarUnProducto([FromBody] SettearUnProducto producto)
        {
            return productoHandler.SettearUnProducto(new Producto
            {
             Id = producto.id,
             Costo = producto.costo,
             IdUsuario = producto.id_usuario,
             Descripcion =producto.descripcion,
             PrecioDeVenta =producto.precio_de_venta,
             Stock = producto.stock,
             

            });
        }






    }


}

