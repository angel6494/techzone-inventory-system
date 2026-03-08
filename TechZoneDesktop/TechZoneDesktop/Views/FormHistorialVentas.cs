using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechZoneDesktop.Services;

namespace TechZoneDesktop.Views
{
    public partial class FormHistorialVentas : Form
    {
        VentaService ventaService = new VentaService();
        private void CargarVentas()
        {
            dgvVentas.DataSource = ventaService.ObtenerVentas();
        }
        public FormHistorialVentas()
        {
            InitializeComponent();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {

            CargarVentas();
    }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
         
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una venta");
                return;
            }

            int idVenta = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["IdVenta"].Value);

            ventaService.EliminarVenta(idVenta);

            MessageBox.Show("Venta eliminada y stock restaurado");

            CargarVentas();
        
    }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
