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
    public partial class frmPedidoaMontarPretenido : MaterialSkin.Controls.MaterialForm

    {
        public frmPedidoaMontarPretenido()
        {
            InitializeComponent();
        }

        private void frmPedidoaMontarPretenido_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

        }

        

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxSiCoordinadoCue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxNoCoordinadoCue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
