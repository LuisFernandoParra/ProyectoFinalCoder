using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class VentasHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public static List<Venta> GetVentas()
        {
            List<Venta> listaObtenerVentas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetVentas = "SELECT * FROM [SistemaGestion].[dbo].[Usuario]";

                
                    using (SqlCommand sqlCommand = new SqlCommand(queryGetVentas, sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Venta venta = new Venta();
                                    venta.IdVenta = Convert.ToInt32(dataReader["Id"]);
                                    venta.Comentarios = dataReader["Nombre"].ToString();
                                    listaObtenerVentas.Add(venta);
                                }
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                
              
            }
            return listaObtenerVentas;
        }
        public static bool  BorrarUnaVenta(int idVenta)
        {
            bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @idVenta";
                SqlParameter SqlParameter = new SqlParameter("idVenta", SqlDbType.BigInt);

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

        public static bool  InsertarUnaVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta](Comentarios)" +
                    "VALUES(@Comentarios)";

                SqlParameter ComentarioParametro = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios };



                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(ComentarioParametro);
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

        public static bool SettearUnaVenta(Venta venta)
        {
            bool resultado = false;
            string query = "UPDATE  Venta " +
                   "SET Comentarios = @ComentariosWHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", venta.IdVenta);
                sqlCommand.Parameters.AddWithValue("@Comentarios", venta.Comentarios);



                sqlConnection.Open();
                int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta la sentencia sql

                if (numberOfRows > 0)
                {
                    resultado = true;
                }
                sqlConnection.Close();





          
            }
            return resultado;
      
        }
    
    
    }
}
