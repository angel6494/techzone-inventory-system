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
    public partial class FormCategorias : Form
    {
        CategoriaService categoriaService = new CategoriaService();

        int categoriaSeleccionadaId = 0;
        private void CargarCategorias()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = categoriaService.ObtenerCategorias();
        }
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            categoria.NombreCategoria = txtNombreCategoria.Text;
            categoria.Descripcion = txtDescripcion.Text;

            categoriaService.AgregarCategoria(categoria);

            CargarCategorias();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                categoriaSeleccionadaId = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IdCategoria"].Value);

                txtNombreCategoria.Text = dgvCategorias.CurrentRow.Cells["NombreCategoria"].Value.ToString();
                txtDescripcion.Text = dgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            categoria.IdCategoria = categoriaSeleccionadaId;
            categoria.NombreCategoria = txtNombreCategoria.Text;
            categoria.Descripcion = txtDescripcion.Text;

            categoriaService.ActualizarCategoria(categoria);

            CargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            categoriaService.EliminarCategoria(categoriaSeleccionadaId);

            CargarCategorias();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            categoriaSeleccionadaId = 0;

            txtNombreCategoria.Clear();
            txtDescripcion.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
