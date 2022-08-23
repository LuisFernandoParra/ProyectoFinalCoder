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
              id_usuario = producto.id_usuario,
              descripcion = producto.descripcion,
              costo = producto.costo,
              stock = producto.stock,
              precio_de_venta = producto.precio_de_venta,
             

            });
        }


        [HttpPut]

        public bool ModificarUnProducto([FromBody] SettearUnProducto producto)
        {
            return productoHandler.SettearUnProducto(new Producto
            {
             id = producto.id,
             costo = producto.costo,
             id_usuario = producto.id_usuario,
             descripcion=producto.descripcion,
             precio_de_venta=producto.precio_de_venta,
             stock = producto.stock,
             

            });
        }






    }


}

