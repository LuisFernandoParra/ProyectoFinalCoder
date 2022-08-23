using System.Data.SqlClient;
using System.Data;
using EjemploDeClase ;
namespace EjemploDeClase
{
    
    
        public static class UsuarioHandler
        {
            public const string ConnectionString = "Server = LAPTOP-JH0D6200; Initial Catalog = SistemaGestion;Trusted_Connection=True";

            public static  List<Usuario> ObtenerUsuarios()
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

            public static  bool BorrarUnUsuario(int id)
            {
                bool resultado = false;
                using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";
                    SqlParameter SqlParameter = new SqlParameter("id", SqlDbType.BigInt);

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

            public static bool InsertarUnUsuario(Usuario usuario)
            {
            bool resultado = false;
                using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
                {
                    string QueryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario](Nombre,Apellido,NombreUsuario,Contraseña,Mail)" +
                        "VALUES(@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail)";
                    SqlParameter NombreParametro = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.nombre };
                    SqlParameter ApellidoParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.apellido };
                    SqlParameter NombreUsuarioParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.nombre_usuario };
                    SqlParameter ContraseñaParametro = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.contrasena };
                    SqlParameter MailParametro = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.mail };

                    SqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(QueryInsert, SqlConnection))
                    {
                        sqlCommand.Parameters.Add(NombreParametro);
                        sqlCommand.Parameters.Add(ApellidoParametro);
                        sqlCommand.Parameters.Add(NombreUsuarioParametro);
                        sqlCommand.Parameters.Add(ContraseñaParametro);
                        sqlCommand.Parameters.Add(MailParametro);

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
            public static bool   SettearUnUsuario(Usuario usuario)
            {
                bool resultado = false;
                string query = "UPDATE Usuario " +
                       "SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail" +
                       "WHERE Id = @id";
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@id", usuario.id);
                    sqlCommand.Parameters.AddWithValue("@Nombre", usuario.nombre_usuario);
                    sqlCommand.Parameters.AddWithValue("@Apellido", usuario.apellido);
                    sqlCommand.Parameters.AddWithValue("@NombreUsuario", usuario.nombre_usuario);
                    sqlCommand.Parameters.AddWithValue("@Contraseña", usuario.contrasena);
                    sqlCommand.Parameters.AddWithValue("@Mail", usuario.mail);



                    sqlConnection.Open();
                    
                    int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta la sentencia sql

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                    sqlConnection.Close();





                }
                return (resultado);
        
        
            }


        }

}


