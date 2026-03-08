using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneDesktop.Models;
using TechZoneDesktop.Services;

namespace TechZoneDesktop.Controllers
{
    public class ClienteController
    {
        ClienteService service = new ClienteService();

        public List<Cliente> ObtenerClientes()
        {
            return service.ObtenerClientes();
        }

        public void GuardarCliente(Cliente cliente)
        {
            service.InsertarCliente(cliente);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            service.ActualizarCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            service.EliminarCliente(id);
        }
    }
}
