using System;
using System.Collections.Generic;
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
    }
}
