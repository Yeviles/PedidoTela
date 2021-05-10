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
    public partial class frmPedidoaMontarCuellos : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        int idSolicitudTelas;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        #endregion

        #region Constructor
        public frmPedidoaMontarCuellos(Controlador control, List<MontajeTelaDetalle> listaSeleccionada, int idsolTela)
        {
            InitializeComponent();
            this.control = control;
            this.idSolicitudTelas = idsolTela;
            DetalleSeleccionado = listaSeleccionada;

        }
        #endregion

        private void frmPedidoaMontarCuellos_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

        }
    }
}
