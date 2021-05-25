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
        private string tipoPedido;
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

        public frmTipoPedidoaMontar(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, string tipoPedido, int idSolTela)
        {
            InitializeComponent();
            detalleSeleccionado = listaSeleccionada;
            control = controlador;
            IdSolTela = idSolTela;
            contItemSeleccionado = listaSeleccionada.Count;
            this.tipoPedido = tipoPedido;
            switch (tipoPedido.ToUpper()) {
                case "UNICOLOR": cbxUnicolor.Checked = true; break;
                case "ESTAMPADO": cbxestampado.Checked = true; break;
                case "PRETEÑIDO": cbxPlanoPretenido.Checked = true; break;
                case "TIRAS/CUELLOS/PUÑOS": cbxCuePunTiras.Checked = true; break;
                case "COORDINADO": cbxCoordinadoTresUno.Checked = true; break;
                case "AGENCIAS EXTERNOS": cbxAgencias.Checked = true; break;
            }
        }

        private void frmTipoPedidoaMontar_Load(object sender, EventArgs e)
        {
            if (tipoPedido.Trim() != "")
            {
                btnAceptar_Click(sender, e);
            }
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
            if (cbxCoordinadoTresUno.Checked)
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
                cbxCoordinadoTresUno.Checked = false;
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
                this.Close();
                frmMontarUnicolor = new frmPedidoaMotarUnicolor(control, detalleSeleccionado,contItemSeleccionado,Seleccion, IdSolTela);
                frmMontarUnicolor.ShowDialog();
            }
            else if (cbxestampado.Checked)
            {
                this.Close();
                frmMontarEstampado = new frmPedidoaMontarEstampado(control, detalleSeleccionado);
                frmMontarEstampado.ShowDialog();
            }
            else if (cbxPlanoPretenido.Checked)
            {
                this.Close();
                frmMontarPretenido = new frmPedidoaMontarPretenido(control, detalleSeleccionado, IdSolTela,contItemSeleccionado);
                frmMontarPretenido.ShowDialog();
            }
            else if (cbxCuePunTiras.Checked)
            {
                this.Close();
                frmMontarCuellos = new frmPedidoaMontarCuellos(control, detalleSeleccionado, IdSolTela);
                frmMontarCuellos.ShowDialog();
            }
            else if (cbxCoordinadoTresUno.Checked)
            {
                this.Close();
                frmMontarCoordinado = new frmPedidoaMontarCoordinado(control, detalleSeleccionado, detalleSeleccionado[0].IdSolTela);
                frmMontarCoordinado.ShowDialog();
            }
            else if (cbxAgencias.Checked)
            {
                this.Close();
                frmPedidoaMontarAgencias = new frmPedidoaMontarAgencias(control, detalleSeleccionado, IdSolTela);
                frmPedidoaMontarAgencias.ShowDialog();
            }
            else {
                MessageBox.Show("Por favor seleccione el tipo de pedido que desea montar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
