namespace EjemploDeClase
{
    public class CrearUnProducto
    {
        public int id_usuario { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precio_de_venta { get; set; }
        public int stock { get; set; }
    }


    public class SettearUnProducto
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precio_de_venta { get; set; }
        public int stock { get; set; }
    }
}
