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

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM Cliente";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Apellido = reader["Apellido"].ToString();
                    cliente.CedulaIdentidad = reader["CedulaIdentidad"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();

                    lista.Add(cliente);
                }
            }

            return lista;
        }

        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO Cliente
                                (Nombre,Apellido,CedulaIdentidad,Telefono)
                                VALUES
                                (@Nombre,@Apellido,@Cedula,@Telefono)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Cedula", cliente.CedulaIdentidad);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE Cliente
                                SET Nombre=@Nombre,
                                    Apellido=@Apellido,
                                    CedulaIdentidad=@Cedula,
                                    Telefono=@Telefono
                                WHERE IdCliente=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Cedula", cliente.CedulaIdentidad);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int id)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM Cliente WHERE IdCliente=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
