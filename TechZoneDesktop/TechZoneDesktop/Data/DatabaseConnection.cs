using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TechZoneDesktop.Data
{
    public class DatabaseConnection
    {
        private string connectionString =
            "Server = DESKTOP-QMEIPIV\\SQLEXPRESS;Database=TechZoneDB;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
