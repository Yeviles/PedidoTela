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
using PedidoTela.Entidades.Logica;
using PedidoTela.Controlodores;
using PedidoTela.Entidades;

namespace PedidoTela.Formularios
{
    public partial class frmPedidoaMontarPretenido : MaterialSkin.Controls.MaterialForm

    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        int idSolicitudTelas=0, id=0;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int IdSolicitudTelas { get => idSolicitudTelas; set => idSolicitudTelas = value; }
        #endregion

        #region Constructor
        public frmPedidoaMontarPretenido(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, int idsolTela)
        {
            
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            this.control = controlador;
            IdSolicitudTelas = idsolTela;
        }
        #endregion

        #region Método inicial de Carga
        private void frmPedidoaMontarPretenido_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //bool b = false;
            //if (txtRendimiento.Text == "")
            //{
            //    MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    if (cbxTipoMarcacion.SelectedIndex != -1)
            //    {
            //        if (txtAnalista.Text != "")
            //        {
            //            if (txtDesPrenda.Text != "")
            //            {

            //                if (dgvInfoConsolidar.RowCount > 0 && dgvTotalConsolidado.RowCount > 0)
            //                {
            //                    bool vacio = false;
            //                    foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            //                    {
            //                        if (row.Cells[11].Value == null || row.Cells[12].Value == null || row.Cells[13].Value == null)
            //                        {
            //                            vacio = true;
            //                        }
            //                    }
            //                    if (!vacio)
            //                    {
            //                        //Se obtiene el encabezado de la vista.
            //                        PedidoAMontar elemento = ObtenerEncabezado();
            //                        if (control.consultarIdPedidoPlano(IdSolicitudTelas))
            //                        {
            //                            control.actualizarPedidoPlano(elemento);
            //                            b = true;
            //                        }
            //                        else
            //                        {
            //                            control.agregarPedidoPlano(elemento);
            //                        }
            //                        //Agrega el Consolidado.
            //                        AgregarConsolidado();

            //                        //Consulta el id que se genero cuando se guarda la infromación del encabezado.
            //                        id = control.getIdPedUnicolor(IdSolicitudTelas);

            //                        //Lista con lis ids de cada uno de los detalles de la vista
            //                        List<int> listaIDInfoConsolidar = control.getIdPedUnicolorInfoCon(id);
            //                        List<int> listaIDtotalconsolidar = control.getIdPedUnicolorTotalCon(id);
            //                        try
            //                        {
            //                            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            //                            {
            //                                //Se obtiene la informacion de la primera dataGridView (dgvInfoConsolidar)
            //                                PedUnicolorInfoCon detalle = ObtenerInfoConsolidar(i);
            //                                if (b)
            //                                {
            //                                    if (i < listaIDInfoConsolidar.Count)
            //                                    {
            //                                        control.actuPedUnicolorInfoCon(detalle, listaIDInfoConsolidar[i]);
            //                                    }
            //                                    else { control.addPedUnicolorInfoCon(detalle); }
            //                                }
            //                                else { control.addPedUnicolorInfoCon(detalle); }
            //                            }
            //                            for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
            //                            {
            //                                //Se obtiene la informacion de la segunada dataGridView (dgvTotalConsolidado)
            //                                PedUnicolorTotalCon detalle = ObtenerTotalConsolidar(i);
            //                                if (b)
            //                                {
            //                                    if (i < listaIDtotalconsolidar.Count)
            //                                    {
            //                                        control.actuaPedUnicolorTotalConsol(detalle, listaIDtotalconsolidar[i]);
            //                                    }
            //                                    else { control.addPedUnicolorTotalCons(detalle); }
            //                                }
            //                                else { control.addPedUnicolorTotalCons(detalle); }
            //                            }

            //                            MessageBox.Show("Pedido Unicolor se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                        catch
            //                        {
            //                            MessageBox.Show("Pedido Unicolor no se pudo guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Los campos Kg Calculados, total a Pedir y unidad de Medida Tela deben estar llenos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Por favor, Ingrese un valor para Descripción Prenda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Por favor, Ingrese un valor para Analista Cortes B.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Por favor, Seleccione un valor para Tipo de Marcación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Métodos

        private void cargarCombobox(ComboBox combo, List<Objeto> lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
            combo.AutoCompleteCustomSource = cargarCombobox(lista);
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        /*<summary> Permite el autocompletado de un comboBox </summary>
         * <param name="lista">Lista de tipo objeto</param>
         * <returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        private PedidoAMontar ObtenerEncabezado()
        {
            PedidoAMontar elemento = new PedidoAMontar();
            elemento.Tela = txtNomTela.Text.Trim();
            elemento.Disenador = txtDisenador.Text.Trim();
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.EnsayoReferencia = txtEnsayoRef.Text.Trim();
            elemento.DescripcionPrenda = txtDesPrenda.Text.Trim();
            elemento.Clase = cbxClase.SelectedItem.ToString();
            elemento.TipoMarcacion = cbxTipoMarcacion.GetItemText(cbxTipoMarcacion.SelectedItem);
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.AnalistasCortesB = txtAnalista.Text.Trim();
            string fecha = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            elemento.FechaLlegada = fecha;
            elemento.IdSolicitud = IdSolicitudTelas;
            return elemento;
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento de dar clic en Guardar.
        /// </summary>
        private void AgregarConsolidado()
        {
            //int maxConsolidado = control.consultarMaxConsolidado();
            //for (int i = 0; i < ListaIdSolicitudes.Count; i++)
            //{
            //    control.agregarConsolidado(ListaIdSolicitudes[i], maxConsolidado + 1, "", "");
            //}

        }

        #endregion

    }
}
