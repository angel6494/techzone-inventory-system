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
using TechZoneDesktop.Views;

namespace TechZoneDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClienteForm form = new ClienteForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHistorialVentas form = new FormHistorialVentas();
            form.Show();
        }
    }
}
