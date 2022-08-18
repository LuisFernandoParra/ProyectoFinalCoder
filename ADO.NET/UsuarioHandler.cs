 using System.Data.SqlClient;
using System.Data;
namespace EjemploDeClase
{
    public class UsuarioHandler
    {
        public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario", SqlConnection))
                {
                    SqlConnection.Open();

                    using (SqlDataReader SqlDataReader = SqlCommand.ExecuteReader())
                    {
                        if (SqlDataReader.HasRows)
                        {
                            while (SqlDataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.mail = SqlDataReader["Mail"].ToString();
                                usuario.nombre_usuario = SqlDataReader["NombreUsuario"].ToString();
                                usuario.contrasena = SqlDataReader["Contraseña"].ToString();
                                usuario.apellido = SqlDataReader["Apellido"].ToString();
                                usuario.nombre = SqlDataReader["Nombre"].ToString();
                                usuario.id = Convert.ToInt32(SqlDataReader["Id"]);

                                Usuarios.Add(usuario);

                            }
                        }
                    }
                    SqlConnection.Close();

                }

            }
            return Usuarios;

      
        }

        public void BorrarUnUsuario(int id)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";
                SqlParameter SqlParameter = new SqlParameter("id", SqlDbType.BigInt);

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, SqlConnection))
                {
                    sqlCommand.Parameters.Add(SqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                SqlConnection.Close();
            }
        }

        public void InsertarUnUsuario(Usuario usuario)
        {
            using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
            {
                string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario](Nombre,Apellido,NombreUsuario,Contraseña,Mail)" +
                    "VALUES(@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail)";
                SqlParameter NombreParametro = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.nombre };
                SqlParameter ApellidoParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.apellido };
                SqlParameter NombreUsuarioParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.nombre_usuario};
                SqlParameter ContraseñaParametro = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.contrasena };
                SqlParameter MailParametro = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.mail};

                SqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                {
                    sqlCommand.Parameters.Add(NombreParametro);
                    sqlCommand.Parameters.Add(ApellidoParametro);
                    sqlCommand.Parameters.Add(NombreUsuarioParametro);
                    sqlCommand.Parameters.Add(ContraseñaParametro);
                    sqlCommand.Parameters.Add(MailParametro);

                    sqlCommand.ExecuteNonQuery();
                }

                SqlConnection.Close();

            }


        }
        public void SettearUnProducto(int Id, string Nombre, string Apellido, string NombreUsuario, string Contraseña,string Mail)
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

