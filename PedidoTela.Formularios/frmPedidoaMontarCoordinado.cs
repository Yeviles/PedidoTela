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
    public partial class frmPedidoaMontarCoordinado : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control;
        private List<MontajeTelaDetalle> listaSolicitudes;
        private List<Objeto> lista = new List<Objeto>();
        private Objeto principal = new Objeto();
        private Objeto coordinado1 = new Objeto();
        private Objeto coordinado2 = new Objeto();
        #endregion

        public frmPedidoaMontarCoordinado(Controlador control, List<MontajeTelaDetalle> listaSolicitudes)
        {
            this.control = control;
            this.listaSolicitudes = listaSolicitudes;
            InitializeComponent();

            cargarCombobox(cbxPrincipal, getListaCombo());
            cargarCombobox(cbxCoordinado1, getListaCombo());
            cargarCombobox(cbxCoordinado2, getListaCombo());
        }

        private void frmPedidoaMontarCoordinado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validarComboBox())
            {
                //frmContenedor frmcontenido = new frmContenedor(control, listaSolicitudes, principal.Id, coordinado1.Id, coordinado2.Id);
                //frmcontenido.ShowDialog();
                frmTipoPedidoCoordinado3en1 frmCoordinado3en1 = new frmTipoPedidoCoordinado3en1(control, listaSolicitudes, principal.Id, coordinado1.Id, coordinado2.Id);
                frmCoordinado3en1.ShowDialog();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cbxPrincipal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxPrincipal.SelectedItem != null)
            {
                Objeto seleccionado = ((Objeto)cbxPrincipal.SelectedItem);
                if (!seleccionado.Id.Equals("0"))
                {
                    principal = seleccionado;
                    foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
                    {
                        if (solicitud.IdDetalleSolicitud.ToString() == seleccionado.Id)
                        {
                            txtTelaPP.Text = solicitud.DesTela;
                            txtReferenciaTelaPP.Text = solicitud.RefTela;
                            txtTipoPedidoPP.Text = solicitud.TipoSolicitud;
                        }
                    }
                }
            }
        }

        private void cbxCoordinado1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxCoordinado1.SelectedItem != null)
            {
                Objeto seleccionado = ((Objeto)cbxCoordinado1.SelectedItem);
                if (!seleccionado.Equals("0"))
                {
                    if (!principal.Id.Equals(seleccionado.Id))
                    {
                        coordinado1 = seleccionado;
                        foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
                        {
                            if (solicitud.IdDetalleSolicitud.ToString() == seleccionado.Id)
                            {
                                txtTelaPC1.Text = solicitud.DesTela;
                                txtReferenciaTelaPC1.Text = solicitud.RefTela;
                                txtTipoPedidoPC1.Text = solicitud.TipoSolicitud;
                            }
                        }
                    }
                    else
                    {
                        txtTelaPC1.Text = "";
                        txtReferenciaTelaPC1.Text = "";
                        txtTipoPedidoPC1.Text = "";
                        MessageBox.Show("El elemento ya ha sido seleccionado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbxCoordinado1.SelectedIndex = -1;
                    }
                }
            }
        }

        private void cbxCoordinado2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxCoordinado2.SelectedItem != null)
            {
                Objeto seleccionado = ((Objeto)cbxCoordinado2.SelectedItem);
                if (!seleccionado.Equals("0"))
                {
                    if (!principal.Id.Equals(seleccionado.Id) && !coordinado1.Id.Equals(seleccionado.Id))
                    {
                        coordinado2 = seleccionado;
                        foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
                        {
                            if (solicitud.IdDetalleSolicitud.ToString() == ((Objeto)cbxCoordinado2.SelectedItem).Id)
                            {
                                txtTelaPC2.Text = solicitud.DesTela;
                                txtReferenciaTelaPC2.Text = solicitud.RefTela;
                                txtTipoPedidoPC2.Text = solicitud.TipoSolicitud;
                            }
                        }
                    }
                    else
                    {
                        txtTelaPC2.Text = "";
                        txtReferenciaTelaPC2.Text = "";
                        txtTipoPedidoPC2.Text = "";
                        MessageBox.Show("El elemento ya ha sido seleccionado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbxCoordinado2.SelectedIndex = -1;
                    }
                }
            }
        }

        private List<Objeto> getListaCombo() {
            List<Objeto> listaObjetos = new List<Objeto>();
            listaObjetos.Add(new Objeto("0", ""));
            foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
            {
                Objeto obj = new Objeto();
                obj.Id = solicitud.IdDetalleSolicitud.ToString();
                obj.Nombre = solicitud.RefSimilar;
                listaObjetos.Add(obj);
            }
            return listaObjetos;
        }

        private bool validarComboBox()
        {
            bool repetido = false;
            if (cbxPrincipal.SelectedIndex > 0 && cbxCoordinado1.SelectedIndex > 0)
            {
                if (principal.Id == coordinado1.Id)
                {
                    repetido = true;
                    MessageBox.Show("Por favor seleccione otro valor para el campo Coordinado 1\nEsta solicitud ya fue seleccionada en el campo Principal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cbxPrincipal.SelectedIndex > 0 && cbxCoordinado2.SelectedIndex > 0)
            {
                if (principal.Id == coordinado2.Id)
                {
                    repetido = true;
                    MessageBox.Show("Por favor seleccione otro valor para el campo Coordinado 2\nEsta solicitud ya fue seleccionada en el campo Principal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cbxCoordinado1.SelectedIndex > 0 && cbxCoordinado2.SelectedIndex > 0)
            {
                if (coordinado1.Id == coordinado2.Id)
                {
                    repetido = true;
                    MessageBox.Show("Por favor seleccione otro valor para el campo Coordinado 2\nEsta solicitud ya fue seleccionada en el campo Coordinado 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return repetido;
        }

        #region Otros métodos
        /*<summary> Realiza la carga de los datos en el ComboBox </summary>
         * <param name="lista">Lista de tipo Objeto</param>
         * <returns></returns>*/
        private void cargarCombobox(ComboBox combo, List<Objeto> lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
            combo.SelectedItem = lista[0];
            combo.AutoCompleteCustomSource = cargarCombobox(lista);
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        ///<summary> Permite el autocompletado de un comboBox </summary>
        ///<param name="lista">Lista de tipo objeto</param>
        /// <returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        #endregion

    }
}
