using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneDesktop.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal TotalVentaBs { get; set; }

        public int ClienteId { get; set; }
    }
}
