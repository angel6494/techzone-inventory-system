using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneDesktop.Data;
using TechZoneDesktop.Models;


namespace TechZoneDesktop.Services
{
    public class VentaService
    {
        ProductoService productoService = new ProductoService();
        private string connectionString =
           "Server = DESKTOP-QMEIPIV\\SQLEXPRESS;Database=TechZoneDB;Trusted_Connection=True;";

        public void RegistrarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryVenta = @"INSERT INTO Venta
                                        (IdCliente,FechaVenta,TotalBs)
                                        OUTPUT INSERTED.IdVenta
                                        VALUES
                                        (@IdCliente,@Fecha,@Total)";

                    SqlCommand cmdVenta = new SqlCommand(queryVenta, conn, transaction);

                    cmdVenta.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                    cmdVenta.Parameters.AddWithValue("@Fecha", venta.FechaVenta);
                    cmdVenta.Parameters.AddWithValue("@Total", venta.TotalBs);

                    int idVenta = (int)cmdVenta.ExecuteScalar();

                    foreach (var detalle in detalles)
                    {
                        string queryDetalle = @"INSERT INTO DetalleVenta
                                               (IdVenta,IdProducto,Cantidad,PrecioUnitarioBs,SubtotalBs)
                                               VALUES
                                               (@IdVenta,@IdProducto,@Cantidad,@Precio,@Subtotal)";

                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction);

                        cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@Precio", detalle.PrecioUnitarioBs);
                        cmdDetalle.Parameters.AddWithValue("@Subtotal", detalle.SubtotalBs);
                        
                        cmdDetalle.ExecuteNonQuery();
                        productoService.DescontarStock(detalle.IdProducto, detalle.Cantidad);

                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
        public DataTable ObtenerVentas()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                        V.IdVenta,
                        C.Nombre,
                        V.FechaVenta,
                        V.TotalBs
                        FROM Venta V
                        INNER JOIN Cliente C
                        ON V.IdCliente = C.IdCliente";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                da.Fill(tabla);
            }

            return tabla;
        }
        public void EliminarVenta(int idVenta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1 Obtener productos vendidos
                    string queryDetalle = @"SELECT IdProducto, Cantidad
                                   FROM DetalleVenta
                                   WHERE IdVenta = @IdVenta";

                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta);

                    List<(int producto, int cantidad)> lista = new List<(int, int)>();

                    SqlDataReader reader = cmdDetalle.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
                    }

                    reader.Close();

                    // 2 Devolver stock
                    foreach (var item in lista)
                    {
                        string updateStock = @"UPDATE Producto
                                      SET Stock = Stock + @Cantidad
                                      WHERE IdProducto = @IdProducto";

                        SqlCommand cmdStock = new SqlCommand(updateStock, conn, transaction);

                        cmdStock.Parameters.AddWithValue("@Cantidad", item.cantidad);
                        cmdStock.Parameters.AddWithValue("@IdProducto", item.producto);

                        cmdStock.ExecuteNonQuery();
                    }

                    // 3 Eliminar detalles
                    string deleteDetalle = "DELETE FROM DetalleVenta WHERE IdVenta=@IdVenta";

                    SqlCommand cmdDeleteDetalle = new SqlCommand(deleteDetalle, conn, transaction);
                    cmdDeleteDetalle.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmdDeleteDetalle.ExecuteNonQuery();

                    // 4 Eliminar venta
                    string deleteVenta = "DELETE FROM Venta WHERE IdVenta=@IdVenta";

                    SqlCommand cmdDeleteVenta = new SqlCommand(deleteVenta, conn, transaction);
                    cmdDeleteVenta.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmdDeleteVenta.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
