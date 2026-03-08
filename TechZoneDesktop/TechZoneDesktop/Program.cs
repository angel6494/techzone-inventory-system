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

           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
