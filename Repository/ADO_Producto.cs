using IntegrandoApi.Model;
using System.Data.SqlClient;

namespace IntegrandoApi.Repository
{
    public class ADO_Producto
    {
        public static void AgregarProducto(Producto produc)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values (@descripciones, @costo, @precioventa, @stock, @idusuario)";

                var paramDescripciones = new SqlParameter();
                paramDescripciones.ParameterName = "descripciones";
                paramDescripciones.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDescripciones.Value = produc.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "costo";
                paramCosto.SqlDbType = System.Data.SqlDbType.Float;
                paramCosto.Value = produc.Costo;

                var paramPrecioventa = new SqlParameter();
                paramPrecioventa.ParameterName = "precioventa";
                paramPrecioventa.SqlDbType = System.Data.SqlDbType.Float;
                paramPrecioventa.Value = produc.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "stock";
                paramStock.SqlDbType = System.Data.SqlDbType.BigInt;
                paramStock.Value = produc.Stock;

                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "idusuario";
                paramIdUsuario.SqlDbType = System.Data.SqlDbType.BigInt;
                paramIdUsuario.Value = produc.IdUsuario;

                cmd.Parameters.Add(paramDescripciones);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPrecioventa);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsuario);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarProducto(Producto produc)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Update Producto set Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioventa, Stock = @stock, IdUsuario = @idusuario where id = @Id";

                var paramId = new SqlParameter();
                paramId.ParameterName = "Id";
                paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                paramId.Value = produc.Id;

                var paramDescripciones = new SqlParameter();
                paramDescripciones.ParameterName = "descripciones";
                paramDescripciones.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDescripciones.Value = produc.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "costo";
                paramCosto.SqlDbType = System.Data.SqlDbType.Float;
                paramCosto.Value = produc.Costo;

                var paramPrecioVenta = new SqlParameter();
                paramPrecioVenta.ParameterName = "precioventa";
                paramPrecioVenta.SqlDbType = System.Data.SqlDbType.Float;
                paramPrecioVenta.Value = produc.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "stock";
                paramStock.SqlDbType = System.Data.SqlDbType.BigInt;
                paramStock.Value = produc.Stock;

                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "idusuario";
                paramIdUsuario.SqlDbType = System.Data.SqlDbType.BigInt;
                paramIdUsuario.Value = produc.IdUsuario;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDescripciones);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPrecioVenta);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsuario);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete from Producto where id = @idUsu";

                var param = new SqlParameter();
                param.ParameterName = "idUsu";
                param.SqlDbType = System.Data.SqlDbType.BigInt;
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
