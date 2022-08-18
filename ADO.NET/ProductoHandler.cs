using System.Data;
using System.Data.SqlClient;
namespace EjemploDeClase
{
    public class productoHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";


        public List<Producto> ObtenerProductos()
        {
            List<Producto> descripciones = new List<Producto>();
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(
                    "SELECT * FROM Producto", SqlConnection))
                {
                    SqlConnection.Open();

                    using (SqlDataReader SqlDataReader = SqlCommand.ExecuteReader())
                    {
                        if (SqlDataReader.HasRows)
                        {
                            while (SqlDataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.id_producto = Convert.ToInt32(SqlDataReader["Id"]);
                                producto.stock = Convert.ToInt32(SqlDataReader["Stock"]);
                                producto.id_usuario = Convert.ToInt32(SqlDataReader["IdUsuario"]);
                                producto.costo = Convert.ToInt32(SqlDataReader["Costo"]);
                                producto.precio_de_venta = Convert.ToInt32(SqlDataReader["PrecioVenta"]);
                                producto.descripcion = SqlDataReader["Descripciones"].ToString();


                                descripciones.Add(producto);

                            }
                        }
                    }
                    SqlConnection.Close();

                }

            }
            return descripciones;

        }

        public void BorrarUnProducto(int idProducto)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @idProducto";
                SqlParameter SqlParameter = new SqlParameter("idProducto", SqlDbType.BigInt);

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, SqlConnection))
                {
                    sqlCommand.Parameters.Add(SqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                SqlConnection.Close();
            }
        }

        public void InsertarUnProducto(Producto producto)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto](Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                    "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)";
                SqlParameter DescripcionesParametro = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.descripcion };
                SqlParameter CostoParametro = new SqlParameter("Costo", SqlDbType.Int) { Value = producto.costo };
                SqlParameter PrecioVentaParametro = new SqlParameter("PrecioVenta", SqlDbType.Int) { Value = producto.precio_de_venta };
                SqlParameter StockParametro = new SqlParameter("Stock", SqlDbType.Int) { Value = producto.stock };
                SqlParameter IdUsuarioParametro = new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.id_usuario };

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(DescripcionesParametro);
                    sqlCommand.Parameters.Add(CostoParametro);
                    sqlCommand.Parameters.Add(PrecioVentaParametro);
                    sqlCommand.Parameters.Add(StockParametro);
                    sqlCommand.Parameters.Add(IdUsuarioParametro);
                    sqlCommand.ExecuteNonQuery();
                }

                SqlConnection.Close();

            }


        }
        public void SettearUnProducto(int Id, string Descripciones, double Costo, double PrecioVenta, int Stock)
        {
            string query = "UPDATE Producto " +
                   "SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock " +
                   "WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@descripciones", Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", Stock);


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();





            }
        } 
    }
}

