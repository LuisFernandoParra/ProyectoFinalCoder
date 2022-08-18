using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class VentasHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public List<Venta> ObtenerVentas()
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
        public void BorrarUnaVenta(int idVenta)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @idVenta";
                SqlParameter SqlParameter = new SqlParameter("idVenta", SqlDbType.BigInt);

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, SqlConnection))
                {
                    sqlCommand.Parameters.Add(SqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                SqlConnection.Close();
            }
        }

        public void InsertarUnaVenta(Venta venta)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta](Comentarios)" +
                    "VALUES(@Comentarios)";

                SqlParameter ComentarioParametro = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.comentarios };
               
         

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(ComentarioParametro);
                    sqlCommand.ExecuteNonQuery();
                }

                SqlConnection.Close();

            }


        }

        public void SettearUnProducto(int Id, string Nombre, string Apellido, string NombreUsuario, string Contraseña, string Mail)
        {
            string query = "UPDATE Usuario " +
                   "SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail" +
                   "WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@Apellido", Apellido);
                sqlCommand.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@Contraseña", Contraseña);
                sqlCommand.Parameters.AddWithValue("@Mail", Mail);



                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();





            }
        }
    }
}
