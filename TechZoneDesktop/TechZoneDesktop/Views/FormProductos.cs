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
    public partial class FormProductos : Form
    {
        CategoriaService categoriaService = new CategoriaService();
        ProductoService productoService = new ProductoService();
        int productoSeleccionadoId = 0;
        public FormProductos()
        {
            InitializeComponent();
        }
        private void CargarCategorias()
        {
            cmbCategoria.DataSource = categoriaService.ObtenerCategorias();

            cmbCategoria.DisplayMember = "NombreCategoria";

            cmbCategoria.ValueMember = "IdCategoria";
        }
        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productoService.ObtenerProductos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();

            CargarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            producto.NombreProducto = txtNombreProducto.Text;
            producto.Marca = txtMarca.Text;
            producto.PrecioBs = Convert.ToDecimal(txtPrecio.Text);
            producto.Stock = Convert.ToInt32(txtStock.Text);

            productoService.AgregarProducto(producto);

            CargarProductos();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Id = productoSeleccionadoId;
            producto.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            producto.NombreProducto = txtNombreProducto.Text;
            producto.Marca = txtMarca.Text;
            producto.PrecioBs = Convert.ToDecimal(txtPrecio.Text);
            producto.Stock = Convert.ToInt32(txtStock.Text);

            productoService.ActualizarProducto(producto);

            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            productoService.EliminarProducto(productoSeleccionadoId);

            CargarProductos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionadoId = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);

                cmbCategoria.SelectedValue = dgvProductos.CurrentRow.Cells["IdCategoria"].Value;

                txtNombreProducto.Text = dgvProductos.CurrentRow.Cells["NombreProducto"].Value.ToString();
                txtMarca.Text = dgvProductos.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["PrecioBs"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            productoSeleccionadoId = 0;

            txtNombreProducto.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            cmbCategoria.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
