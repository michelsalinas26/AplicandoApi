using IntegrandoApi.Model;
using IntegrandoApi.Repository;
using System.Data;
using System.Data.SqlClient;

namespace IntegrandoApi.Repository
{
    public class ADO_Venta
    {
        public static void AgregarVenta(Venta venta)

        {
            using (var oConn = new SqlConnection(General.connectionString()))
            {
                try
                {
                    oConn.Open();

                    var query = "  INSERT INTO Venta(Comentarios, IdUsuario) VALUES (@comentario, @iduser);";

                    var oCmd = new SqlCommand(query, oConn);

                    oCmd.Parameters.Add(new SqlParameter("comentario", System.Data.SqlDbType.VarChar) { Value = venta.Comentarios });
                    oCmd.Parameters.Add(new SqlParameter("iduser", System.Data.SqlDbType.BigInt) { Value = venta.IdUsuario });
                    var result = oCmd.ExecuteNonQuery();
                    
                    if (result == 0)
                        throw new Exception("No se pudo insertar el registro solicitado");

                    var ultimaVenta = TraerUltimoVenta();

                    /* insertar lista de productos vendidos */

                    foreach (ProductoVendido producto in venta.Productos)
                    {
                        //Agregar lista de productos vendidos
                        oCmd = new SqlCommand("INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta)", oConn);
                        oCmd.CommandType = CommandType.Text;
                        oCmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt)).Value = producto.Stock;
                        oCmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                        oCmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = ultimaVenta.Id;
                        oCmd.ExecuteNonQuery();
                        //Actualizar Stock en Productos
                        oCmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE id = @IdProducto", oConn);
                        oCmd.CommandType = CommandType.Text;
                        oCmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                        oCmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                        oCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    oConn.Close();
                }
            }
        }

        public static Venta TraerUltimoVenta()
        {
            var venta = new Venta();

            using (var oConn = new SqlConnection(General.connectionString()))
            {
                oConn.Open();

                var query = "Select Max(id) From Venta";

                var oCmd = new SqlCommand(query, oConn);

                using (var oDr = oCmd.ExecuteReader())
                {
                    if (oDr.HasRows)
                    {
                        while (oDr.Read())
                        {
                            venta.Id = Convert.ToInt32(oDr.GetValue(0));
                        }
                    }
                }

                oConn.Close();
            }

            return venta;

        }
    }
}

