namespace EjemploDeClase
{
    public class ProductoVendido
    {
        public int id { get; set; }
        public int id_ventas { get; set; }
        public int stock_ventas { get; set; }
        public int id_producto2 { get; set; }

        public ProductoVendido(int id_Producto_Vendido, int stock_ventas, int Id_Usuario, int id_producto2, int id)
        {

            this.id_ventas = id_Producto_Vendido;
            this.stock_ventas = stock_ventas;
            this.id_producto2 = id_producto2;
            this.id = id;   
        }

        public ProductoVendido()
        {
            id = 0;
            id_ventas = 0;
            stock_ventas = 0;
            id_producto2 = 0;
        }
    }



}