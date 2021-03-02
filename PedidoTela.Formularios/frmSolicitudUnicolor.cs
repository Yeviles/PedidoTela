using MaterialSkin;
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
        public frmSolicitudUnicolor()
        {
            InitializeComponent();
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
    }
}
