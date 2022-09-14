using EjemploDeClase;
using Microsoft.AspNetCore.Mvc;


namespace EjemploDeClase
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public List<Producto> GetProductosVendidos()
        {

            return productoHandler.ObtenerProductos();


        }

        [HttpDelete]

        public bool EliminarProductoVendido([FromBody] int id)
        {
            return ProductoVendidoHandler.BorrarUnProductoVendido(id);
        }



        [HttpPost]

        public bool InsertarUnProductoVendido([FromBody] InsertarProductoVendido  productoVendido)
        {
            return ProductoVendidoHandler.InsertarUnProductoVendido(new ProductoVendido
            {
                id_producto2 = productoVendido.IdProducto,
                id_ventas = productoVendido.IdVenta,
                stock_ventas = productoVendido.Stock
                
                 


            });
        }


        [HttpPut]

        public bool ModificarUnProductoVendido([FromBody] SettearProductoVendido productoVendido )
        {
            return ProductoVendidoHandler.SettearUnProductoVendido(new ProductoVendido
            {
               stock_ventas=productoVendido.Stock,
               id_producto2 = productoVendido.IdProducto,
               id = productoVendido.id,
               id_ventas=productoVendido.IdVenta,
            });
        }






    }


}