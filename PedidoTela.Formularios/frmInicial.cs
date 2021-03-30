using System;
using MaterialSkin;
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
    public partial class frmInicial : MaterialSkin.Controls.MaterialForm
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void btnSolicitudTelas_Click(object sender, EventArgs e)
        {
            frmSolicitudTela frmSolicitud = new frmSolicitudTela();
            frmSolicitud.Show();
        }

        private void btnMontajePedidoTelas_Click(object sender, EventArgs e)
        {
            frmSolicitudListaTelas frmListaTelas = new frmSolicitudListaTelas();
            frmListaTelas.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInicial_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey400, Primary.Grey100, Accent.Green100, TextShade.WHITE);
        }
    }
}
