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
    public partial class frmTipoPedidoaMontar : Form
    {
        private String seleccion;
        private Controlador control= new Controlador();
        List<DetalleListaTela> detalleSeleccionado = new List<DetalleListaTela>();
        int contItemSeleccionado = 0;

        public string Seleccion { get => seleccion; set => seleccion = value; }
        public List<DetalleListaTela> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }

        public frmTipoPedidoaMontar(Controlador controlador, List<DetalleListaTela> listaSeleccionada, int contador)
        {
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            control = controlador;
            contItemSeleccionado = contador;
            
        }

        private void cbxUnicolor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUnicolor.Checked)
            {

                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "unicolor";
                frmPedidoaMotarUnicolor frmMontarUnicolor = new frmPedidoaMotarUnicolor(control, DetalleSeleccionado,contItemSeleccionado,Seleccion);

            }
        }

        private void cbxestampado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxestampado.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "estampado";
            }
        }

        private void cbxPlanoPretenido_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlanoPretenido.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "planoPre";
            }
        }

        private void cbxCuePunTiras_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCuePunTiras.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                Seleccion = "cuelloPun";
            }
        }

        private void cbxCdoTresUno_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCdoTresUno.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "cdoTresUno";
            }
        }

        private void cbxAgencias_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAgencias.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                cbxCdoTresUno.Checked = false;
                Seleccion = "agencias";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
