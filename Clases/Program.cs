using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCare.forms.administrador;
using AutoCare.forms.opcionales;
using ConnectApp.Database;

namespace AutoCare
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseConnection dbTest = new DatabaseConnection();

            if (!dbTest.ProbarConexion())
            {
                // Conexión FALLIDA: Muestra el error y NO llama a Application.Run.
                string mensajeError = "Error de Conexión a la Base de Datos.\n\n" +
                                      "La aplicación no puede continuar. Presione Aceptar para salir.";

                MessageBox.Show(mensajeError, "Error Crítico de Conexión",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                // El programa simplemente termina aquí (no hay Application.Run())
                return;
            }

            // Conexión EXITOSA: Muestra el mensaje de éxito.
            string mensajeExito = "Conexión a la Base de Datos exitosa.";

            // Nota: El MessageBox es modal y requiere hacer clic en Aceptar.
            // Si quisiera que se cerrara solo en 3 segundos, necesitaría un Formulario
            // de "Splash Screen" separado con un Timer.
            MessageBox.Show(mensajeExito, "Conexión Exitosa",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);


            // 2. Si la conexión fue exitosa, INICIA la aplicación mostrando el FormHome.
            Application.Run(new PreLogin());
        }
    }
}
