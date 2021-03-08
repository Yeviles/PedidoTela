using MaterialSkin;
using PedidoTela.Controlodores;
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
    public partial class frmSolicitudPlanoPretenido : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private string identificador;
        private string codigoTela;
        public frmSolicitudPlanoPretenido(Controlador control, string identificador, string codigoTela)
        {
            this.control = control;
            this.identificador = identificador;
            this.codigoTela = codigoTela;
            InitializeComponent();
        }

        private void frmSolicitudPlanoPretenido_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);


        }
    }
}
