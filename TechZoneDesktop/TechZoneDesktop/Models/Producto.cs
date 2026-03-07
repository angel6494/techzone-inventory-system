using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneDesktop.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public decimal PrecioBs { get; set; }

        public int Stock { get; set; }

        public int CategoriaId { get; set; }
    }
}
