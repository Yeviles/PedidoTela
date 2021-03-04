using PedidoTela.Controlodores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSolicitudTela());
           //Application.Run(new frmSolicitudUnicolor(new Controlador(), "DSQUARED"));
            // Application.Run(new frmTipoPedSelecCoordinar());/*B*/
            //Application.Run(new frmSolicitudPlanoPretenido());
            //Application.Run(new frmSolicitudListaTelas()); /*B*/
            //Application.Run(new frmSolicitudEstampado());
            //Application.Run(new frmSolicitudCuellosTiras());
            //Application.Run(new frmReservaTela());
            //Application.Run(new frmPedidoaMotarUnicolor());
            //Application.Run(new frmPedidoaMontarPretenido());
            //Application.Run(new frmPedidoaMontarEstampado());
            //Application.Run(new frmPedidoaMontarCuellos());
            //Application.Run(new frmPrueba());
        }
    }
}
