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
    public partial class frmEditar : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        Controlador control = new Controlador();
        Validar validacion = new Validar();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        string tipoPedido;
        frmPedidoaMotarUnicolor frmMontarUnicolor;
        frmPedidoaMontarEstampado frmMontarEstampado;
        frmPedidoaMontarPretenido frmMontarPretenido;
        frmPedidoaMontarCuellos frmMontarCuellos;
        frmPedidoaMontarCoordinado frmMontarCoordinado;
        frmPedidoaMontarAgencias frmPedidoaMontarAgencias;
        #endregion

        #region Constructor
        public frmEditar(Controlador control, int consecutivo,string tipoPedido, List<MontajeTelaDetalle> listaSeleccionada)
        {
            InitializeComponent();
            this.control = control;
            this.tipoPedido = tipoPedido;
            detalleSeleccionado = listaSeleccionada;
            txbConsecutivo.Text = consecutivo.ToString();
            
        }
        #endregion

        #region Método inicial de carga
        private void frmEditar_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

        }
        #endregion

        #region Eventos
        private void txbConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tipoPedido != "")
            {
                if (txbConsecutivo.Text != "")
                {
                    if (control.existeConsecutivo(int.Parse(txbConsecutivo.Text)))
                    {
                        if (tipoPedido == "UNICOLOR")
                        {
                            frmMontarUnicolor = new frmPedidoaMotarUnicolor(control, detalleSeleccionado, detalleSeleccionado.Count, "UNICOLOR", detalleSeleccionado[0].IdSolTela);
                            frmMontarUnicolor.ShowDialog();
                        }
                        else if (tipoPedido == "ESTAMPADO")
                        {
                            frmMontarEstampado = new frmPedidoaMontarEstampado(control, detalleSeleccionado);
                            frmMontarEstampado.ShowDialog();
                        }
                        else if (tipoPedido == "PLANO")
                        {
                           frmMontarPretenido = new frmPedidoaMontarPretenido(control, detalleSeleccionado, detalleSeleccionado[0].IdSolTela, detalleSeleccionado.Count);

                            frmMontarPretenido.ShowDialog();
                        }
                        else if (tipoPedido == "CUELLOS")
                        {
                            frmMontarCuellos = new frmPedidoaMontarCuellos(control, detalleSeleccionado, detalleSeleccionado[0].IdSolTela);
                            frmMontarCuellos.ShowDialog();
                        }
                        else if (tipoPedido == "COORDINADO")
                        {
                            frmMontarCoordinado = new frmPedidoaMontarCoordinado(control, detalleSeleccionado, detalleSeleccionado[0].IdSolTela);
                            frmMontarCoordinado.ShowDialog();
                        }
                        else if (tipoPedido == "AGENCIAS EXTERNOS")
                        {
                            frmPedidoaMontarAgencias = new frmPedidoaMontarAgencias(control, detalleSeleccionado, detalleSeleccionado[0].IdSolTela);
                            frmPedidoaMontarAgencias.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El consecutivo ingresado no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor para Consecutivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                CargarPedidos();
            }
        }
        #endregion

        #region Métodos
        private void CargarPedidos()
        {
            if (txbConsecutivo.Text != "")
            {
                if (control.existeConsecutivo(int.Parse(txbConsecutivo.Text)))
                {
                    if (control.consultarEstado(int.Parse(txbConsecutivo.Text)))
                    {
                        string tipoPedido = control.tipoPedido(int.Parse(txbConsecutivo.Text));
                        MontajeTela objTela = new MontajeTela();
                        objTela.TipoSolicitud = "";
                        objTela.Muestrario = ""; objTela.OcasionUso = ""; objTela.Tema = "";
                        objTela.Entrada = ""; objTela.Disenador = ""; objTela.EnsayoRefSimilar = ""; objTela.Estado = "";
                        objTela.FechaTienda = ""; objTela.RefTela = ""; objTela.NomTela = ""; objTela.Solicitud = "";
                        objTela.Color = ""; objTela.Clase = ""; objTela.Coordinado = ""; objTela.NumDibujo = "";
                        objTela.ConsecutivoPedido = int.Parse(txbConsecutivo.Text);
                        List<MontajeTelaDetalle> montajeTelaDetalles = control.consultarListaTelas(objTela);
                        if (tipoPedido == "UNICOLOR")
                        {
                            frmMontarUnicolor = new frmPedidoaMotarUnicolor(control, montajeTelaDetalles, montajeTelaDetalles.Count, "UNICOLOR", montajeTelaDetalles[0].IdSolTela);
                            frmMontarUnicolor.ShowDialog();
                        }
                        else if (tipoPedido == "ESTAMPADO")
                        {
                            frmMontarEstampado = new frmPedidoaMontarEstampado(control, montajeTelaDetalles);
                            frmMontarEstampado.ShowDialog();
                        }
                        else if (tipoPedido == "PLANO")
                        {
                           frmMontarPretenido = new frmPedidoaMontarPretenido(control, montajeTelaDetalles, montajeTelaDetalles[0].IdSolTela, montajeTelaDetalles.Count);
                           frmMontarPretenido.ShowDialog();
                        }
                        else if (tipoPedido == "CUELLOS")
                        {
                            frmMontarCuellos = new frmPedidoaMontarCuellos(control, montajeTelaDetalles, montajeTelaDetalles[0].IdSolTela);
                            frmMontarCuellos.ShowDialog();
                        }
                        else if (tipoPedido == "COORDINADO")
                        {
                            frmMontarCoordinado = new frmPedidoaMontarCoordinado(control, montajeTelaDetalles, montajeTelaDetalles[0].IdSolTela);
                            frmMontarCoordinado.ShowDialog();
                        }
                        else if (tipoPedido == "AGENCIAS EXTERNOS")
                        {
                            frmPedidoaMontarAgencias = new frmPedidoaMontarAgencias(control, montajeTelaDetalles, montajeTelaDetalles[0].IdSolTela);
                            frmPedidoaMontarAgencias.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estado no corresponde a Devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                     MessageBox.Show("El consecutivo ingresado no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor para Consecutivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

    }
}
