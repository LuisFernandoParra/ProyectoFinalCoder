using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public List<Producto_Vendido> ObtenerProductosVendidos()
        {
            List<Producto_Vendido> ProductosVendidos = new List<Producto_Vendido>();
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
                                Producto_Vendido producto_Vendido = new Producto_Vendido();
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

        public void BorrarUnProductoVendido(int idProducto)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @idProductoVendido";
                SqlParameter SqlParameter = new SqlParameter("idProductoVendido", SqlDbType.BigInt);

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, SqlConnection))
                {
                    sqlCommand.Parameters.Add(SqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                SqlConnection.Close();
            }
        }


        public void InsertarUnProductoVendido(Producto_Vendido producto_Vendido)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido](IdVenta,Stock,IdProducto)" +
                    "VALUES(@IdVenta,@Stock,@IdProducto)";

                SqlParameter IdVentaParametro = new SqlParameter("IdVenta", SqlDbType.Int) { Value = producto_Vendido.id_ventas};
                SqlParameter Stock2Parametro = new SqlParameter("Stock", SqlDbType.Int) { Value = producto_Vendido.stock_ventas  };
                SqlParameter IdPoductoVendidoParametro = new SqlParameter("IdProducto", SqlDbType.Int) { Value = producto_Vendido.id_producto2 };

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(IdPoductoVendidoParametro);
                    sqlCommand.Parameters.Add(Stock2Parametro);
                    sqlCommand.Parameters.Add(IdPoductoVendidoParametro);
                    sqlCommand.ExecuteNonQuery();
                }

                SqlConnection.Close();

            }


        }

        public void SettearUnProductoVendido(int id,int IdVenta, int IdproductoVendido, int Stock2)
        {
            string query = "UPDATE ProductoVendido " +
                   "SET IdVenta = @IdVenta, IdProducto = @IdProducto, Stock = @stock " +
                   "WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@costo", IdVenta);
                sqlCommand.Parameters.AddWithValue("@stock", Stock2);
                sqlCommand.Parameters.AddWithValue("@IdProductoVendido",IdproductoVendido );


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();





            }
        }

    }


}