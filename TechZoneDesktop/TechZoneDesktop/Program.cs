using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechZoneDesktop.Data;

namespace TechZoneDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                SqlConnection conn = db.GetConnection();
                conn.Open();

                MessageBox.Show("Conexion exitosa a la base de datos");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion: " + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
