using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TechZoneDesktop.Models;
using TechZoneDesktop.Data;

namespace TechZoneDesktop.Services
{
    public class ClienteService
    {
        DatabaseConnection db = new DatabaseConnection();

        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Cliente (Nombre, Apellido, CedulaIdentidad, Telefono) VALUES (@Nombre, @Apellido, @Cedula, @Telefono)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Cedula", cliente.CedulaIdentidad);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
