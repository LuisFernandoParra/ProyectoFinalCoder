using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public static List<ProductoVendido> ObtenerProductosVendidos()
        {
            List<ProductoVendido> ProductosVendidos = new List<ProductoVendido>();
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", SqlConnection))
                {
                    SqlConnection.Open();

                    using (SqlDataReader SqlDataReader = SqlCommand.ExecuteReader())
                    {
                        if (SqlDataReader.HasRows)
                        {
                            while (SqlDataReader.Read())
                            {
                                ProductoVendido producto_Vendido = new ProductoVendido();
                                producto_Vendido.id_ventas = Convert.ToInt32(SqlDataReader["IdVenta"]);
                                producto_Vendido.stock_ventas = Convert.ToInt32(SqlDataReader["Stock"]);
                                producto_Vendido.id_producto2 = Convert.ToInt32(SqlDataReader["IdProducto"]);


                                ProductosVendidos.Add(producto_Vendido);

                            }
                        }
                    }
                    SqlConnection.Close();

                }

            }
            return ProductosVendidos;

        }

        public static bool BorrarUnProductoVendido(int idProducto)
        {
            bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @idProductoVendido";
                SqlParameter SqlParameter = new SqlParameter("idProductoVendido", SqlDbType.BigInt);

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


        public static bool InsertarUnProductoVendido(ProductoVendido producto_Vendido)
        {
            bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido](IdVenta Stock IdProducto)" +
                    "VALUES(@IdVenta @Stock @IdProducto)";

                SqlParameter IdVentaParametro = new SqlParameter("IdVenta", SqlDbType.Int) { Value = producto_Vendido.id_ventas };
                SqlParameter Stock2Parametro = new SqlParameter("Stock", SqlDbType.Int) { Value = producto_Vendido.stock_ventas };
                SqlParameter IdPoductoVendidoParametro = new SqlParameter("IdProducto", SqlDbType.Int) { Value = producto_Vendido.id_producto2 };

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(IdPoductoVendidoParametro);
                    sqlCommand.Parameters.Add(Stock2Parametro);
                    sqlCommand.Parameters.Add(IdPoductoVendidoParametro);
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

        public static bool  SettearUnProductoVendido(ProductoVendido producto_Vendido)
        {
            bool resultado = false;
            string query = "UPDATE ProductoVendido " +
                   "SET IdVenta = @IdVenta IdProducto = @IdProducto Stock = @stock " +
                   "WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", producto_Vendido.id);
                sqlCommand.Parameters.AddWithValue("@stock", producto_Vendido.stock_ventas);
                sqlCommand.Parameters.AddWithValue("@IdProductoVendido",producto_Vendido.id_producto2);


                sqlConnection.Open();
                int numberofrows = sqlCommand.ExecuteNonQuery();

                if (numberofrows > 0)
                {
                    resultado = true;
                }
                sqlConnection.Close();





            }
            return resultado;
        } 
        
    }


}