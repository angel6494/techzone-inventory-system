using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneDesktop.Models;
using TechZoneDesktop.Data;



namespace TechZoneDesktop.Services
{
    public class ProductoService
    {
        private string connectionString =
            "Server = DESKTOP-QMEIPIV\\SQLEXPRESS;Database=TechZoneDB;Trusted_Connection=True;";
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();

                    p.Id = reader.GetInt32(reader.GetOrdinal("IdProducto"));
                    p.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
                    p.NombreProducto = reader["NombreProducto"].ToString();
                    p.Marca = reader["Marca"].ToString();
                    p.PrecioBs = Convert.ToDecimal(reader["PrecioBs"]);
                    p.Stock = Convert.ToInt32(reader["Stock"]);

                    lista.Add(p);
                }
            }

            return lista;
        }


        public void AgregarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Producto
                        (IdCategoria,NombreProducto,Marca,PrecioBs,Stock)
                        VALUES
                        (@IdCategoria,@Nombre,@Marca,@Precio,@Stock)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                cmd.Parameters.AddWithValue("@Precio", producto.PrecioBs);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Producto
                        SET IdCategoria=@IdCategoria,
                            NombreProducto=@Nombre,
                            Marca=@Marca,
                            PrecioBs=@Precio,
                            Stock=@Stock
                        WHERE IdProducto=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                cmd.Parameters.AddWithValue("@Precio", producto.PrecioBs);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@Id", producto.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE IdProducto=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
