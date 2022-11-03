using IntegrandoApi.Model;
using System.Data.SqlClient;

namespace IntegrandoApi.Repository
{
    public class ADO_ProductoVendido
    {
        public static void EliminarProductoVendido(int id)
        {
            using (var oConn = new SqlConnection(General.connectionString()))
            {
                oConn.Open();

                var query = "delete from productoVendido where IdProducto = @idProducto;";

                var oCmd = new SqlCommand(query, oConn);

                oCmd.Parameters.Add(new SqlParameter("idProducto", System.Data.SqlDbType.BigInt) { Value = id });

                oCmd.ExecuteNonQuery();
                oConn.Close();
            }
        }
    }
}
