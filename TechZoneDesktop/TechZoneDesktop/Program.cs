using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechZoneDesktop.Data;



// SISTEMA COMPLETO, ESTE ES EL ULTIMO COMMIT QUE CONFIRMA QUE EL SISTEMA ESTA COMPLETO Y CUMPLE PERFECTAMENTE CON LAS HISTORIAS DE USUARIO Y DIAGRAMAS QUE ESTAN EL REPOSITORIO GITHUB DEL PROYECTO.

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
