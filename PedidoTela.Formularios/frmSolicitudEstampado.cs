using MaterialSkin;
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
    public partial class frmSolicitudEstampado : MaterialSkin.Controls.MaterialForm
    {
        Validar validacion = new Validar();
        public frmSolicitudEstampado()
        {
            InitializeComponent();
        }

        private void frmSolicitudEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            //if (txbCoordinaCon.MaxLength > 40)
            //{
                txbCoordinaCon.MaxLength = 40;
                //errorProvider.SetError(txbSku, "Ingrese solo 3 caracteres");
            //}

        }
        public void recibirInfoTela(string prmRefTela, string nomTela)
        {
            txbRefTela.Text= prmRefTela;
            txbNomTela.Text = nomTela;
        }

        private void txbNdibujo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);

        }

        private void txbNcilindro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmTipoSolicitud frmTsolicitud = new frmTipoSolicitud();
            frmTsolicitud.Show();
        }
    }
}
