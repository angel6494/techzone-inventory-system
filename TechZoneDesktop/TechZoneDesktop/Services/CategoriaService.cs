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
        public void AgregarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Categoria
                        (NombreCategoria,Descripcion)
                        VALUES
                        (@Nombre,@Descripcion)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Categoria
                        SET NombreCategoria=@Nombre,
                            Descripcion=@Descripcion
                        WHERE IdCategoria=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                cmd.Parameters.AddWithValue("@Id", categoria.IdCategoria);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarCategoria(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Categoria WHERE IdCategoria=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
