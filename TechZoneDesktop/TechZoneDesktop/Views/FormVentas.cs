using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechZoneDesktop.Models;
using TechZoneDesktop.Services;

namespace TechZoneDesktop.Views
{
    public partial class FormVentas : Form
    {
        VentaService ventaService = new VentaService();
        ProductoService productoService = new ProductoService();
        ClienteService clienteService = new ClienteService();

        List<DetalleVenta> listaDetalle = new List<DetalleVenta>();
        private void CargarClientes()
        {
            cmbClientes.DataSource = clienteService.ObtenerClientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";
        }
        private void CargarProductos()
        {
            cmbProductos.DataSource = productoService.ObtenerProductos();
            cmbProductos.DisplayMember = "NombreProducto";
            cmbProductos.ValueMember = "Id";
        }
        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                total += Convert.ToDecimal(row.Cells[3].Value);
            }

            txtTotal.Text = total.ToString();
        }
        public FormVentas()
        {
            InitializeComponent();
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            dgvDetalleVenta.Columns.Add("Producto", "Producto");
            dgvDetalleVenta.Columns.Add("Precio", "Precio");
            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("Subtotal", "Subtotal");
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese cantidad");
                return;
            }
            Producto producto = (Producto)cmbProductos.SelectedItem;

            int cantidad = Convert.ToInt32(txtCantidad.Text);
            // VALIDAR STOCK
            if (cantidad > producto.Stock)
            {
                MessageBox.Show("No hay suficiente stock");
                return;
            }


            decimal precio = producto.PrecioBs;

            decimal subtotal = precio * cantidad;

            DetalleVenta detalle = new DetalleVenta()
            {
                IdProducto = producto.Id,
                Cantidad = cantidad,
                PrecioUnitarioBs = precio,
                SubtotalBs = subtotal
            };

            listaDetalle.Add(detalle);

            dgvDetalleVenta.Rows.Add(
                producto.NombreProducto,
                precio,
                cantidad,
                subtotal
            );

            CalcularTotal();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "")
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta");
                return;
            }
            Venta venta = new Venta();

            venta.IdCliente = Convert.ToInt32(cmbClientes.SelectedValue);
            venta.FechaVenta = DateTime.Now;
            venta.TotalBs = Convert.ToDecimal(txtTotal.Text);

            ventaService.RegistrarVenta(venta, listaDetalle);

            MessageBox.Show("Venta registrada correctamente");

            dgvDetalleVenta.Rows.Clear();
            listaDetalle.Clear();
            txtTotal.Clear();
        
    }

        private void cmbProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                Producto producto = (Producto)cmbProductos.SelectedItem;

                txtPrecio.Text = producto.PrecioBs.ToString();
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && txtPrecio.Text != "")
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal precio = Convert.ToDecimal(txtPrecio.Text);

                decimal subtotal = cantidad * precio;

                txtSubtotal.Text = subtotal.ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
