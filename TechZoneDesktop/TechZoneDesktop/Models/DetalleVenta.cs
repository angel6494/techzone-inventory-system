using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneDesktop.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitarioBs { get; set; }

        public decimal SubtotalBs { get; set; }

        public int ProductoId { get; set; }

        public int VentaId { get; set; }
    }
}
