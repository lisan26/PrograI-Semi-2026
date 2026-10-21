using System;
using System.IO;
using System.Windows.Forms;

namespace miPrimeaAplicacion {
    internal static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            string carpetaProyecto = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".."));
            if (File.Exists(Path.Combine(carpetaProyecto, "db_academica.mdf"))) {
                AppDomain.CurrentDomain.SetData("DataDirectory", carpetaProyecto);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
