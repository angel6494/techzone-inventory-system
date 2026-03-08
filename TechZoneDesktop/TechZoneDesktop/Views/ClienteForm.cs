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
        ClienteController controller = new ClienteController();

        public ClienteForm()
        {
            InitializeComponent();
        }
        private void CargarClientes()
        {
            dgvClientes.DataSource = controller.ObtenerClientes();
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

            controller.GuardarCliente(cliente);

            MessageBox.Show("Cliente guardado correctamente");

            CargarClientes();
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvClientes.CurrentRow.Cells["Id"].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtCedula.Text = dgvClientes.CurrentRow.Cells["CedulaIdentidad"].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Id = int.Parse(txtId.Text);
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.CedulaIdentidad = txtCedula.Text;
            cliente.Telefono = txtTelefono.Text;

            controller.ActualizarCliente(cliente);

            MessageBox.Show("Cliente actualizado");

            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            controller.EliminarCliente(id);

            MessageBox.Show("Cliente eliminado");

            CargarClientes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
