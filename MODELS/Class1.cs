namespace EjemploDeClase
{

    public class Usuario
    {
        public int id{get; set;}
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena { get; set; }
        public string mail { get; set; }


        public Usuario()
        {
            id = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            nombre_usuario = string.Empty;
            contrasena = string.Empty;
            mail = string.Empty;
        }

        public Usuario(int id, string nombre, string apellido, string nombre_usuario, string contrasena, string mail)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombre_usuario = nombre_usuario;
            this.contrasena = contrasena;
            this.mail = mail;
        }

    }


    public class Producto
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precio_de_venta { get; set; }
        public int stock { get; set; }
        public int id_usuario { get; set; }



        public Producto(int id_producto, string descripcion, double costo, double precio_de_venta, int stock, int id_usuario)
        {
            this.id_producto = id_producto;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precio_de_venta = precio_de_venta;
            this.stock = stock;
            this.id_usuario = id_usuario;
        }

        public Producto()
        {
            id_producto = 0;
            descripcion= string.Empty;
            costo = 0;
            precio_de_venta = 0;
            stock = 0;
            id_usuario = 0;
        }
    }


    public class Producto_Vendido
    {
        public int id_ventas { get; set; }
        public int stock_ventas { get; set; }
        public int id_producto2 { get; set; }

        public Producto_Vendido(int id_Producto_Vendido, int stock_ventas, int Id_Usuario, int id_producto2)
        {
            this.id_ventas = id_Producto_Vendido;
            this.stock_ventas = stock_ventas;
            this.id_producto2 = id_producto2;
        }

        public Producto_Vendido()
        {
            id_ventas=0;
            stock_ventas=0;
            id_producto2 = 0;
        }
    }

    public class Venta
    {
        public int id_venta { get; set; }
        public string comentarios { get; set; }

        public Venta(int id_venta, string comentarios)
        {
            this.id_venta = id_venta;
            this.comentarios = comentarios;
        }

        public Venta()
        {
            id_venta=0;
            comentarios = string.Empty;
        }
    }


















}