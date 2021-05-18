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
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        int contItemSeleccionado = 0, idSolTela;
        frmPedidoaMotarUnicolor frmMontarUnicolor;
        frmPedidoaMontarEstampado frmMontarEstampado;
        frmPedidoaMontarPretenido frmMontarPretenido;
        frmPedidoaMontarCuellos frmMontarCuellos;
        frmPedidoaMontarCoordinado frmMontarCoordinado;
        frmPedidoaMontarAgencias frmPedidoaMontarAgencias;

        public string Seleccion { get => seleccion; set => seleccion = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }

        public frmTipoPedidoaMontar(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, int contador, int idSolTela)
        {
            InitializeComponent();
            detalleSeleccionado = listaSeleccionada;
            control = controlador;
            IdSolTela = idSolTela;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbxUnicolor.Checked)
            {
                frmMontarUnicolor = new frmPedidoaMotarUnicolor(control, detalleSeleccionado,contItemSeleccionado,Seleccion, IdSolTela);
                frmMontarUnicolor.ShowDialog();
                this.Close();
            }
            else if (cbxestampado.Checked)
            {
                frmMontarEstampado = new frmPedidoaMontarEstampado(control, detalleSeleccionado);
                frmMontarEstampado.ShowDialog();
                this.Close();
            }
            else if (cbxPlanoPretenido.Checked)
            {
                frmMontarPretenido = new frmPedidoaMontarPretenido(control, detalleSeleccionado, IdSolTela,contItemSeleccionado);
                frmMontarPretenido.ShowDialog();
                this.Close();
            }
            else if (cbxCuePunTiras.Checked)
            {
                frmMontarCuellos = new frmPedidoaMontarCuellos(control, detalleSeleccionado, IdSolTela);
                frmMontarCuellos.ShowDialog();
                this.Close();
            }
            else if (cbxCdoTresUno.Checked)
            {
                frmMontarCoordinado = new frmPedidoaMontarCoordinado(control, detalleSeleccionado);
                frmMontarCoordinado.ShowDialog();
                this.Close();
            }
            else if (cbxAgencias.Checked)
            {
                frmPedidoaMontarAgencias.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Por favor seleccione el tipo de pedido que desea montar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
