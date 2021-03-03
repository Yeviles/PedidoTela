using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmSolicitudUnicolor : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private string codigoTela;
        public frmSolicitudUnicolor(Controlador control, string codigoTela)
        {
            this.control = control;
            this.codigoTela = codigoTela;
            InitializeComponent();
            TipoTejido tt = control.getTipoTejido(codigoTela);
            txbRefTela.Text = tt.CodigoTela;
            txbNomTela.Text = tt.NombreTela;
            txbTipoTejido.Text = tt.NombreTipoTela;
        }

        private void frmSolicitudUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmTipoSolicitud frmTsoli = new frmTipoSolicitud();
            frmTsoli.Show();            
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                lbCoordinaCon.Visible = true;
                txbCoordinaCon.Visible = true;
                cbxNoCoordinado.Checked = false;
            }
            else {
                lbCoordinaCon.Visible = false;
                txbCoordinaCon.Visible = false;
            }
        }

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked) {
                cbxSiCoordinado.Checked = false;
            }
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {

        }
    }
}
