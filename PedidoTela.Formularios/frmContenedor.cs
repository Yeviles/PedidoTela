using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;

namespace PedidoTela.Formularios
{
    public partial class frmContenedor : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control = new Controlador();
        private List<MontajeTelaDetalle> listaSolicitudes = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaUnicolor = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaEstampado = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaPlano = new List<MontajeTelaDetalle>();
        #endregion

        public frmContenedor(Controlador control, List<MontajeTelaDetalle> solicitudes, string principal, string coordinado1, string coordinado2)
        {
            this.control = control;
            this.listaSolicitudes = solicitudes;
            cargarListas();
            InitializeComponent();


            if (listaUnicolor.Count > 0)
            {
                abrirFormEnPanelContenedor1(new frmPedidoaMotarUnicolor(control, listaUnicolor, listaUnicolor.Count, "unicolor", listaUnicolor[0].IdSolTela));
            }
            else {
                ((Control)this.tabPage1).Enabled = false;
            }

            if (listaEstampado.Count > 0)
            {
                abrirFormEnPanelContenedor2(new frmPedidoaMontarEstampado(control, listaEstampado));
            }
            else {
                ((Control)this.tabPage2).Enabled = false;
            }

            if (listaPlano.Count > 0)
            {
                abrirFormEnPanelContenedor3(new frmPedidoaMontarPretenido(control, listaPlano, listaPlano[0].IdSolTela, listaPlano.Count));
            }
            else {
                ((Control)this.tabPage3).Enabled = false;
            }
        }

        private void cargarListas() {
            foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
            {
                if (solicitud.TipoSolicitud.ToLower() == "unicolor")
                {
                    listaUnicolor.Add(solicitud);
                }
                else if (solicitud.TipoSolicitud.ToLower() == "estampado")
                {
                    listaEstampado.Add(solicitud);
                }
                if (solicitud.TipoSolicitud.ToLower() == "preteñido")
                {
                    listaPlano.Add(solicitud);
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        #region otros métodos

        public void abrirFormEnPanelContenedor1(Object formHijo)
        {
            if (this.pnlContenido.Controls.Count > 0)
                this.pnlContenido.Controls.RemoveAt(0);
            Form frmHijo = formHijo as Form;
            frmHijo.TopLevel = false;
            frmHijo.Dock = DockStyle.Fill;
            this.pnlContenido.Controls.Add(frmHijo);
            this.pnlContenido.Tag = frmHijo;
            frmHijo.Show();
        }

        public void abrirFormEnPanelContenedor2(Object formHijo)
        {
            if (this.pnlContenido2.Controls.Count > 0)
                this.pnlContenido2.Controls.RemoveAt(0);
            Form frmHijo = formHijo as Form;
            frmHijo.TopLevel = false;
            frmHijo.Dock = DockStyle.Fill;
            this.pnlContenido2.Controls.Add(frmHijo);
            this.pnlContenido2.Tag = frmHijo;
            frmHijo.Show();
        }

        public void abrirFormEnPanelContenedor3(Object formHijo)
        {
            if (this.pnlContenido3.Controls.Count > 0)
                this.pnlContenido3.Controls.RemoveAt(0);
            Form frmHijo = formHijo as Form;
            frmHijo.TopLevel = false;
            frmHijo.Dock = DockStyle.Fill;
            this.pnlContenido3.Controls.Add(frmHijo);
            this.pnlContenido3.Tag = frmHijo;
            frmHijo.Show();
        }
        #endregion
    }
}
