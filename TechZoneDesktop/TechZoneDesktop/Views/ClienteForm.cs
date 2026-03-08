using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneDesktop.Controllers;
using TechZoneDesktop.Models;
using System.Windows.Forms;

namespace TechZoneDesktop.Views
{
    public partial class ClienteForm : Form

    {
        ClienteController clienteController = new ClienteController();

        public ClienteForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.CedulaIdentidad = txtCedula.Text;
            cliente.Telefono = txtTelefono.Text;

            clienteController.GuardarCliente(cliente);

            MessageBox.Show("Cliente guardado correctamente");

            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
        }
    }
}
