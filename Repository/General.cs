using System.Data.SqlClient;

namespace IntegrandoApi.Repository
{
    public class General
    {
        public static string connectionString()
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "MARCOSLEAL1\\MSSQLSERVER01";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            return (cs);
        }
    }
}
