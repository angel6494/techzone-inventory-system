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
        ClienteService clienteService = new ClienteService();

        public void GuardarCliente(Cliente cliente)
        {
            clienteService.InsertarCliente(cliente);
        }
    }
}
