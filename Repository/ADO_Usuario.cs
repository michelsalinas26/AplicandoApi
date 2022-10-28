using IntegrandoApi.Model;
using System.Data.SqlClient;

namespace IntegrandoApi.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select * from usuario";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                    usuario.Nombre = reader2.GetValue(1).ToString();
                    usuario.Apellido = reader2.GetValue(2).ToString();
                    usuario.NombreUsuario = reader2.GetValue(3).ToString();
                    usuario.Contraseña = reader2.GetValue(4).ToString();
                    usuario.Mail = reader2.GetValue(5).ToString();

                    listaUsuarios.Add(usuario);
                }
                reader2.Close();
                connection.Close();
            }
            return listaUsuarios;
        }

        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete from usuario where id = @idUsu";

                var param = new SqlParameter();
                param.ParameterName = "idUsu";
                param.SqlDbType = System.Data.SqlDbType.BigInt;
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario us)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Update Usuario set Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail where id = @Id";

                var paramId = new SqlParameter();
                paramId.ParameterName = "Id";
                paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                paramId.Value = us.Id;

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "Nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNombre.Value = us.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "Apellido";
                paramApellido.SqlDbType = System.Data.SqlDbType.VarChar;
                paramApellido.Value = us.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "NombreUsuario";
                paramNombreUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNombreUsuario.Value = us.NombreUsuario;

                var paramContraseña = new SqlParameter();
                paramContraseña.ParameterName = "Contraseña";
                paramContraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                paramContraseña.Value = us.Contraseña;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "Mail";
                paramMail.SqlDbType = System.Data.SqlDbType.VarChar;
                paramMail.Value = us.Mail;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContraseña);
                cmd.Parameters.Add(paramMail);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void AgregarUsuario(Usuario us)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail) values(@Nombre, @Apellido, @NombreUsuario, @Contraseña,@Mail)";

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "Nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNombre.Value = us.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "Apellido";
                paramApellido.SqlDbType = System.Data.SqlDbType.VarChar;
                paramApellido.Value = us.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "NombreUsuario";
                paramNombreUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNombreUsuario.Value = us.NombreUsuario;

                var paramContraseña = new SqlParameter();
                paramContraseña.ParameterName = "Contraseña";
                paramContraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                paramContraseña.Value = us.NombreUsuario;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "Mail";
                paramMail.SqlDbType = System.Data.SqlDbType.VarChar;
                paramMail.Value = us.NombreUsuario;

                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContraseña);
                cmd.Parameters.Add(paramMail);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
