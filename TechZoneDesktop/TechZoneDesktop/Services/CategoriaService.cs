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
    public class CategoriaService
    {
        private string connectionString =
            "Server = DESKTOP-QMEIPIV\\SQLEXPRESS;Database=TechZoneDB;Trusted_Connection=True;";

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categoria";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
                    categoria.NombreCategoria = reader["NombreCategoria"].ToString();
                    categoria.Descripcion = reader["Descripcion"].ToString();

                    lista.Add(categoria);
                }
            }

            return lista;
        }
    }
}
