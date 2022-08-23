using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class VentasHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public static  List<Venta> ObtenerVentas()
        {
            List<Venta> Ventas = new List<Venta>();
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", SqlConnection))
                {
                    SqlConnection.Open();

                    using (SqlDataReader SqlDataReader = SqlCommand.ExecuteReader())
                    {
                        if (SqlDataReader.HasRows)
                        {
                            while (SqlDataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.id_venta = Convert.ToInt32(SqlDataReader["Id"]);
                                venta.comentarios = SqlDataReader["Comentarios"].ToString();

                                Ventas.Add(venta);

                            }
                        }
                    }
                    SqlConnection.Close();

                }

            }
            return Ventas;

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

                SqlParameter ComentarioParametro = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.comentarios };



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
                   "SET Comentarios = @Comentarios, WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", venta.id_venta);
                sqlCommand.Parameters.AddWithValue("@Comentarios", venta.comentarios);



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
