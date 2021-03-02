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
    public partial class frmPedidoaMotarUnicolor : MaterialSkin.Controls.MaterialForm
    {
        public frmPedidoaMotarUnicolor()
        {
            InitializeComponent();
        }

        private void frmPedidoaMotarUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

        }





        //public void frmPedidoaMontarUnicolor(object sender, EventArgs e)
        //{
        //    SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
        //    //SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Blue900, Primary.Blue900, Accent.Green700, TextShade.WHITE);
        //    SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Blue900, Primary.Blue900, Accent.Blue700, TextShade.BLACK);

        //}
    }
}
