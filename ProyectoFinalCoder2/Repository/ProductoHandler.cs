using System.Data;
using System.Data.SqlClient;
namespace EjemploDeClase
{
    public class productoHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";


        public static List<Producto> ObtenerProductos()
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
                                producto.Id= Convert.ToInt32(SqlDataReader["Id"]);
                                producto.Stock = Convert.ToInt32(SqlDataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(SqlDataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(SqlDataReader["Costo"]);
                                producto.PrecioDeVenta = Convert.ToInt32(SqlDataReader["PrecioVenta"]);
                                producto.Descripcion = SqlDataReader["Descripciones"].ToString();


                                descripciones.Add(producto);

                            }
                        }
                    }
                    SqlConnection.Close();

                }

            }
            return descripciones;

        }

        public static bool BorrarUnProducto(int idProducto)
        {
             bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @idProducto";
                SqlParameter SqlParameter = new SqlParameter("idProducto", SqlDbType.BigInt);

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, SqlConnection))
                {
                    sqlCommand.Parameters.Add(SqlParameter);
                    int numberofrows = sqlCommand.ExecuteNonQuery();

                    if (numberofrows > 0)
                    {
                        resultado = true;
                    }
                }

                SqlConnection.Close();
         
            }
            return resultado;
        }


        public static bool  InsertarUnProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto](Descripciones Costo PrecioVenta Stock IdUsuario)" +
                    "VALUES(@Descripciones @Costo @PrecioVenta @Stock @IdUsuario)";
                SqlParameter DescripcionesParametro = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion };
                SqlParameter CostoParametro = new SqlParameter("Costo", SqlDbType.Int) { Value = producto.Costo };
                SqlParameter PrecioVentaParametro = new SqlParameter("PrecioVenta", SqlDbType.Int) { Value = producto.PrecioDeVenta };
                SqlParameter StockParametro = new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock };
                SqlParameter IdUsuarioParametro = new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario };

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(DescripcionesParametro);
                    sqlCommand.Parameters.Add(CostoParametro);
                    sqlCommand.Parameters.Add(PrecioVentaParametro);
                    sqlCommand.Parameters.Add(StockParametro);
                    sqlCommand.Parameters.Add(IdUsuarioParametro);
                    int numberofrows = sqlCommand.ExecuteNonQuery();

                    if (numberofrows > 0)
                    {
                        resultado = true;
                    }
                }

                SqlConnection.Close();

            }
            return resultado;

        }
        public static bool SettearUnProducto(Producto producto)
        {
            bool resultado = false;
            string query = "UPDATE Producto " +
                   "SET Descripciones = @descripciones Costo = @costo PrecioVenta = @precioVenta Stock = @stock " +
                   "WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", producto.Id);
                sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioDeVenta);
                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);


                sqlConnection.Open();
                int numberofrows = sqlCommand.ExecuteNonQuery();

                if (numberofrows > 0)
                {
                    resultado = true;
                }
                sqlConnection.Close();

                sqlConnection.Close();





         
            }
            return resultado;
        
   
        } 
   
   
    }   
}


