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
using System.Text.RegularExpressions;

namespace PedidoTela.Formularios
{
    public partial class frmPedidoaMontarPretenido : MaterialSkin.Controls.MaterialForm

    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        List<int> listaIdSolicitudes = new List<int>();
        Utilidades utilidades = new Utilidades();
        Validar validacion = new Validar();
        bool bandera = false, noTejer = false;
        int idSolicitudTelas=0, id, consecutivo;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int IdSolicitudTelas { get => idSolicitudTelas; set => idSolicitudTelas = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }
        #endregion

        #region Constructor
        public frmPedidoaMontarPretenido(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, int idsolTela,int contador)
        {        
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            this.control = controlador;
            IdSolicitudTelas = idsolTela;       
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
        }
        #endregion

        #region Método inicial de Carga
        private void frmPedidoaMontarPretenido_Load(object sender, EventArgs e)
        {
            CargarSolicicitudes(DetalleSeleccionado);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            Iniciar(DetalleSeleccionado);

            #region ToolTips
            dgvInfoConsolidar.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns[21].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInfoConsolidar.Columns[23].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInfoConsolidar.Columns[24].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvTotalConsolidado.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns[2].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns[20].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvTotalConsolidado.Columns[21].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
            #endregion
        }
        #endregion

        #region Eventos

        private void txtAnalista_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        
        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRendimiento.Text.Trim() != "")
            {
                validacion.validarDecimal(sender, e);
            }
        }
             
        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[i].Cells[23].Value != null && dgvInfoConsolidar.Rows[i].Cells[23].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[23].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInfoConsolidar.Rows[i].Cells[24].Value = utilidades.calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[i].Cells[24].Value = 0;
                    }
                }

                calcularTotalesPorColores();
            }
            catch
            {
                txtRendimiento.Text = "";
            }
        }
       
        private void cbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClase.SelectedIndex != -1 && cbxClase.SelectedItem.ToString() == "No Tejer")
            {
                this.noTejer = true;
                btnAgregarPedido.Enabled = true;
            }
            else
            {
                this.noTejer = false;
            }
        }
       
        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 11 && e.ColumnIndex < 20 || e.ColumnIndex == 21 || e.ColumnIndex >=23)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
       
        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <= 21)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
        
        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInfoConsolidar.CurrentRow.Cells[13].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[14].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[15].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[16].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[17].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[18].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[19].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[21].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[23].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[24].ReadOnly = true;

            if (e.RowIndex > -1 && e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvTotalConsolidado.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                    }
                }
            }
            calcularTotalesPorColores();
        }
        
        private void dgvTotalConsolidado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for(int i=0; i <= 21; i++)
            {
                dgvTotalConsolidado.CurrentRow.Cells[i].ReadOnly = true;
            }
 
        }

        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 20) //Cuando cambia el consumo [20] cambia M Calculados [21] y kg Calculado [24]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvInfoConsolidar.CurrentCell.Value = dgvInfoConsolidar.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvInfoConsolidar.CurrentCell.Value = Regex.Replace(dgvInfoConsolidar.CurrentCell.Value.ToString(), @"[^0-9.]", "");

                        if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal consumo = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            int totalUnidades = int.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[19].Value.ToString());
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value = utilidades.calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [21] se actualiza M Solicitar [23]
                            if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value.ToString());

                                if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[22].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[22].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[22].Value.ToString());
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = utilidades.calcularMSolicitar(mCalculados, mReservados);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[24].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                                }
                                else
                                {
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[24].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = "";
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else if (e.ColumnIndex == 21) // cuando cambia M Calculados [21] se actualiza M Solicitar [23]
            {
                if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value.ToString());

                    if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[22].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[22].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = utilidades.calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = "";
                }
            }

            else if (e.ColumnIndex == 22) // cuando cambia M Reservados [22] cambia el M Solicitar [23]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar = utilidades.calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[24].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            dgvInfoConsolidar.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value = dgvInfoConsolidar.Rows[e.RowIndex].Cells[21].Value;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[24].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[23].Value.ToString()) / decimal.Parse(txtRendimiento.Text),2);

                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            calcularTotalesPorColores();
        }
        
        private void dgvTotalConsolidado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 22)
            {
                try
                {
                    if (dgvTotalConsolidado.CurrentCell.Value != null && dgvTotalConsolidado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = decimal.Parse(dgvTotalConsolidado.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvTotalConsolidado.CurrentCell.Value = valor;
                    }
                }
                catch
                {
                    dgvTotalConsolidado.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nUnicamente se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Guarda toda la información de la vista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.noTejer && dgvPedidos.RowCount == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtRendimiento.Text != "")
                {
                    if (cbxTipoMarcacion.Text != "")
                    {
                        if (txtAnalista.Text != "")
                        {
                            if (txtDesPrenda.Text != "")
                            {
                                if (!ValidarCamposInfo())
                                {
                                    if (!ValidarCamosTotal())
                                    {
                                        //Se obtiene el encabezado de la vista.
                                        PedidoAMontar elemento = ObtenerEncabezado();
                                        if (control.existePedidoPlano(IdSolicitudTelas))
                                        {
                                            control.actualizarPedidoPlano(elemento);
                                        }
                                        else
                                        {
                                            control.agregarPedidoPlano(elemento);
                                        }

                                        //Consulta el id que se genero cuando se guarda la infromación del encabezado.
                                        id = control.getIdPedplano(IdSolicitudTelas);
                                        if (id != 0)
                                        {
                                            control.eliminarPedidoPlanoTotal(id);
                                            control.eliminarPedidoPlanoInformacion(id);
                                            control.eliminarPedido(id);

                                            GuardarPedido(id);
                                            GuardarInformacionConsolidar(id);
                                            GuardarTotalConsolidar(id);
                                        }

                                        //Agrega el Consolidado.
                                        AgregarConsolidado();

                                        MessageBox.Show("Pedido Plano Preteñido se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Total a Pedir y unidad de Medida Tela deben estar llenos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Consumo y M Reservados deben estar llenos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Por favor, Ingrese un valor para Descripción Prenda.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, Ingrese un valor para Analista Cortes B.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, Seleccione un valor para Tipo de Marcación.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        /// <summary>
        ///  Boton  confirmar, el  sistema  genera   un  consecutivo   y   la   solicitud     cambia  al   estado   Radicado.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int maxConsecutivo = control.consultarMaxConsecutivoPedido();
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            // El estado que se le debe dar a solicitud cuando es confirmada

            string estado = "Radicado";

            if (id != 0)
            {
                for (int i = 0; i < ListaIdSolicitudes.Count; i++)
                {
                    control.agregarConsecutivo(ListaIdSolicitudes[i], maxConsecutivo + 1, fechaActual, estado);
                }
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Radicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;

                dgvInfoConsolidar.ReadOnly = true;
                dgvTotalConsolidado.ReadOnly = true;

                //consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivoPedido(IdSolicitudTelas);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Imprime los datos del consolidado, una vez este se encuentre guardado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PedidoAMontar objPlano = control.getPedidoPlano(IdSolicitudTelas);
            if (objPlano.Id != 0)
            {
                frmImprimirPedidoPlano frmPedUnicolor = new frmImprimirPedidoPlano(control, IdSolicitudTelas);
                frmPedUnicolor.Show();
            }
            else
            {
                MessageBox.Show("El consolidado no ha sido guardado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        /// <summary>
        /// Cierra la Vista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Permite llevar a cabo la acción de tomar del pedido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            frmBuscarPedido buscar = new frmBuscarPedido(control, DetalleSeleccionado[0].IdProgramador);
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                TomarDelPedido obj = buscar.Elemento;
                dgvPedidos.Rows.Add();
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[0].Value = obj.NumeroPedido;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[1].Value = obj.CodigoColor;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[2].Value = obj.Estado;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[3].Value = obj.Disponible;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Permite cargar una lista con todos los id_solicitud seleccionados.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle,representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void CargarSolicicitudes(List<MontajeTelaDetalle> prmLista)
        {
            List<int> listaSolicitudes = new List<int>();
            for (int i=0;i < prmLista.Count;i++)
            {
                listaSolicitudes.Add(prmLista[i].IdSolTela);
            }
            ListaIdSolicitudes = listaSolicitudes.Distinct().ToList();
        }

        /// <summary>
        /// Busca la información en las respectivas entidades si encuentra dastos los carga y la bandera el True, de lo contrario la bandera es False y se procede a 
        /// cargar la vista con la información que se ha seleccionado de la vista anterior.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas). </param>
        private void Iniciar(List<MontajeTelaDetalle> prmLista)
        {          
            Cargar();
            // Bandera controlada en el método Cargar()
            if (!this.bandera)
            {
                //Carga el DataGridView (dgvInfoConsolidar) el cual pertenece a la sección de información a consolidar.
                cargarDgvInfoConsolidar(prmLista);
                //Carga el DataGridView (dgvTotalConsolidado) el cual pertenece a la sección de total consolidado.
                cargarDgvTotalConsolidar(prmLista);
            }     
        }

        /// <summary>
        /// Carga el primer DataGridView expuesto en la vista, corresponde a información a consolidar.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvInfoConsolidar.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].CodigoH1.ToString(),
                    prmLista[i].DescripcionH1.ToString(),
                    prmLista[i].CodigoH2.ToString(),
                    prmLista[i].DescripcionH2.ToString(),
                    prmLista[i].CodigoH3.ToString(),
                    prmLista[i].DescripcionH3.ToString(),
                    prmLista[i].CodigoH4.ToString(),
                    prmLista[i].DescripcionH4.ToString(),
                    prmLista[i].CodigoH5.ToString(),
                    prmLista[i].DescripcionH5.ToString(),
                    prmLista[i].Tiendas.ToString(),
                    prmLista[i].Exito.ToString(),
                    prmLista[i].Cencosud.ToString(),
                    prmLista[i].Sao.ToString(),
                    prmLista[i].Comercio.ToString(),
                    prmLista[i].Rosado.ToString(),
                    prmLista[i].Otros.ToString(),
                    prmLista[i].TotaUnidades.ToString(),
                    prmLista[i].Consumo.ToString(),
                    prmLista[i].MCalculados.ToString(),
                    prmLista[i].MReservados.ToString(),
                    prmLista[i].Masolicitar.ToString()
                    );

                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();
                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Carga el segundo DataGridView expuesto en la vista, corresponde a total consolidar.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void cargarDgvTotalConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvTotalConsolidado.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].CodigoH1.ToString(),
                    prmLista[i].DescripcionH1.ToString(),
                    prmLista[i].CodigoH2.ToString(),
                    prmLista[i].DescripcionH2.ToString(),
                    prmLista[i].CodigoH3.ToString(),
                    prmLista[i].DescripcionH3.ToString(),
                    prmLista[i].CodigoH4.ToString(),
                    prmLista[i].DescripcionH4.ToString(),
                    prmLista[i].CodigoH5.ToString(),
                    prmLista[i].DescripcionH5.ToString(),
                    prmLista[i].Tiendas.ToString(),
                    prmLista[i].Exito.ToString(),
                    prmLista[i].Cencosud.ToString(),
                    prmLista[i].Sao.ToString(),
                    prmLista[i].Comercio.ToString(),
                    prmLista[i].Rosado.ToString(),
                    prmLista[i].Otros.ToString(),
                    prmLista[i].TotaUnidades.ToString(),
                    prmLista[i].MCalculados.ToString()
                    );

                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Carga la informacion de los ComboBox.
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="lista"></param>
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

        ///<summary> Permite el autocompletado de un comboBox </summary>
        ///<param name="lista">Lista de tipo objeto</param>
        ///<returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento de dar clic en Guardar.
        /// </summary>
        private void AgregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < ListaIdSolicitudes.Count; i++)
            {
                //Permite agregar el consolidado a todas las solicitudes seleccionadas, recibe id_solicitud y consolidado
                control.agregarConsolidado(ListaIdSolicitudes[i], maxConsolidado + 1);
            }

        }
        
        /// <summary>
        /// Obtiene la información del encabezado de la vista.
        /// </summary>
        /// <returns>Retorna un Objeto de Tipo Pedido a Montar, representa la información del encabezado.</returns>
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
        /// Guarda la información de la primera dataGridView (dgvInfoConsolidar)
        /// </summary>
        /// <param name="id">Id del Pedido Plano Preteñido.</param>
        private void GuardarInformacionConsolidar(int id)
        {
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {


                PedidoMontarInformacion detalle = new PedidoMontarInformacion();
                detalle.IdPedidoAMontar = id;
                detalle.CodigoColor = (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionColor = (dgvInfoConsolidar.Rows[i].Cells[1].Value != null && dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() : "";
                detalle.CodigoH1 = (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() : "";
                detalle.DescripcionH1 = (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() : "";
                detalle.CodigoH2 = (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() : "";
                detalle.DescripcionH2 = (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() : "";
                detalle.CodigoH3 = (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() : "";
                detalle.DescripcionH3 = (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() : "";
                detalle.CodigoH4 = (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() : "";
                detalle.DescripcionH4 = (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() : "";
                detalle.CodigoH5 = (dgvInfoConsolidar.Rows[i].Cells[10].Value != null && dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() : "";
                detalle.DescripcionH5 = (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() : "";
                detalle.Tiendas = (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.Exito = (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
                detalle.Cencosud = (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
                detalle.Sao = (dgvInfoConsolidar.Rows[i].Cells[15].Value != null && dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvInfoConsolidar.Rows[i].Cells[16].Value != null && dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString()) : 0;
                detalle.Rosado = (dgvInfoConsolidar.Rows[i].Cells[17].Value != null && dgvInfoConsolidar.Rows[i].Cells[17].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[17].Value.ToString()) : 0;
                detalle.Otros = (dgvInfoConsolidar.Rows[i].Cells[18].Value != null && dgvInfoConsolidar.Rows[i].Cells[18].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[18].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvInfoConsolidar.Rows[i].Cells[19].Value != null && dgvInfoConsolidar.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[19].Value.ToString()) : 0;
                detalle.Consumo = (dgvInfoConsolidar.Rows[i].Cells[20].Value != null && dgvInfoConsolidar.Rows[i].Cells[20].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[20].Value.ToString()) : 0;
                detalle.MCalculados = (dgvInfoConsolidar.Rows[i].Cells[21].Value != null && dgvInfoConsolidar.Rows[i].Cells[21].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[21].Value.ToString()) : 0;
                detalle.MReservados = (dgvInfoConsolidar.Rows[i].Cells[22].Value != null && dgvInfoConsolidar.Rows[i].Cells[22].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[22].Value.ToString()) : 0;
                detalle.MSolicitar = (dgvInfoConsolidar.Rows[i].Cells[23].Value != null && dgvInfoConsolidar.Rows[i].Cells[23].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[23].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvInfoConsolidar.Rows[i].Cells[24].Value != null && dgvInfoConsolidar.Rows[i].Cells[24].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[24].Value.ToString()) : 0;
                control.addPedidoPlanoInfo(detalle);
            }

        }

        /// <summary>
        /// Guarda la información de la segunada dataGridView (dgvTotalConsolidado)
        /// </summary>
        /// <param name="id">Id del pedido Plano Prteñido.</param>
        private void GuardarTotalConsolidar(int id)
        {
            for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
            {
                PedidoMontarTotal detalle = new PedidoMontarTotal();
                detalle.IdPedidoAmontar = id;
                detalle.CodidoColor = (dgvTotalConsolidado.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionColor = (dgvTotalConsolidado.Rows[i].Cells[1].Value != null && dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() : "";
                detalle.CodigoH1 = (dgvTotalConsolidado.Rows[i].Cells[2].Value != null && dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.DescripcionH1 = (dgvTotalConsolidado.Rows[i].Cells[3].Value != null && dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString() : "";
                detalle.CodigoH2 = (dgvTotalConsolidado.Rows[i].Cells[4].Value != null && dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.DescripcionH2 = (dgvTotalConsolidado.Rows[i].Cells[5].Value != null && dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString() : "";
                detalle.CodigoH3 = (dgvTotalConsolidado.Rows[i].Cells[6].Value != null && dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.DescripcionH3 = (dgvTotalConsolidado.Rows[i].Cells[7].Value != null && dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString() : "";
                detalle.CodigoH4 = (dgvTotalConsolidado.Rows[i].Cells[8].Value != null && dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.DescripcionH4 = (dgvTotalConsolidado.Rows[i].Cells[9].Value != null && dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString() : "";
                detalle.CodigoH5 = (dgvTotalConsolidado.Rows[i].Cells[10].Value != null && dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.DescripcionH5 = (dgvTotalConsolidado.Rows[i].Cells[11].Value != null && dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString() : "";
                detalle.Tiendas = (dgvTotalConsolidado.Rows[i].Cells[12].Value != null && dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.Exito = (dgvTotalConsolidado.Rows[i].Cells[13].Value != null && dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString()) : 0;
                detalle.Cencosud = (dgvTotalConsolidado.Rows[i].Cells[14].Value != null && dgvTotalConsolidado.Rows[i].Cells[14].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[14].Value.ToString()) : 0;
                detalle.Sao = (dgvTotalConsolidado.Rows[i].Cells[15].Value != null && dgvTotalConsolidado.Rows[i].Cells[15].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[15].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvTotalConsolidado.Rows[i].Cells[16].Value != null && dgvTotalConsolidado.Rows[i].Cells[16].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[16].Value.ToString()) : 0;
                detalle.Rosado = (dgvTotalConsolidado.Rows[i].Cells[17].Value != null && dgvTotalConsolidado.Rows[i].Cells[17].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[17].Value.ToString()) : 0;
                detalle.Otros = (dgvTotalConsolidado.Rows[i].Cells[18].Value != null && dgvTotalConsolidado.Rows[i].Cells[18].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[18].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvTotalConsolidado.Rows[i].Cells[19].Value != null && dgvTotalConsolidado.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[19].Value.ToString()) : 0;
                detalle.MCalculados = (dgvTotalConsolidado.Rows[i].Cells[20].Value != null && dgvTotalConsolidado.Rows[i].Cells[20].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[20].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvTotalConsolidado.Rows[i].Cells[21].Value != null && dgvTotalConsolidado.Rows[i].Cells[21].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[21].Value.ToString()) : 0;
                detalle.TotalPedir = (dgvTotalConsolidado.Rows[i].Cells[22].Value != null && dgvTotalConsolidado.Rows[i].Cells[22].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[22].Value.ToString()) : 0;
                detalle.UnidadMedida = (dgvTotalConsolidado.Rows[i].Cells[23].Value != null && dgvTotalConsolidado.Rows[i].Cells[23].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[23].Value.ToString() : "";
                control.addPedPlanoTotal(detalle);
            }
            
        }

        /// <summary>
        /// Guarda la información correspondiente a la sección de Tomar del Pedido.
        /// </summary>
        /// <param name="id">Id del Pedido Plano Preteñido.</param>
        private void GuardarPedido(int id)
        {
            for (int i = 0; i < dgvPedidos.RowCount; i++)
            {
                TomarDelPedido pedido = new TomarDelPedido();
                pedido.IdPedidoMontar = id;
                pedido.NumeroPedido = (dgvPedidos.Rows[i].Cells[0].Value.ToString());
                pedido.CodigoColor = (dgvPedidos.Rows[i].Cells[1].Value != null && dgvPedidos.Rows[i].Cells[1].Value.ToString() != "") ? int.Parse(dgvPedidos.Rows[i].Cells[1].Value.ToString()) : 0;
                pedido.Estado = (dgvPedidos.Rows[i].Cells[2].Value != null && dgvPedidos.Rows[i].Cells[2].Value.ToString() != "") ? dgvPedidos.Rows[i].Cells[2].Value.ToString() : "";
                pedido.Disponible = (dgvPedidos.Rows[i].Cells[3].Value != null && dgvPedidos.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvPedidos.Rows[i].Cells[3].Value.ToString()) : 0;
                pedido.TipoPedido = "PRETEÑIDO";
                control.addPedido(pedido);
            }
        }

        /// <summary>
        /// Válida que algunos campos requeridos del DatagridView (dgvInfoConsolidar) no esten vacíos.
        /// </summary>
        /// <returns>Retorna True si los campos estan vacíos, Falso de lo contrario.</returns>
        private bool ValidarCamposInfo()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
            {
                if (row.Cells[21].Value == null || row.Cells[22].Value == null)
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Válida que algunos campos requeridos del DatagridView (idgvTotalConsolidado) no esten vacíos.
        /// </summary>
        /// <returns>Retorna True si los campos estan vacíos, Falso de lo contrario.</returns>
        private bool ValidarCamosTotal()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                if (row.Cells[22].Value == null || row.Cells[23].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
           
        }

        /// <summary>
        ///  Calcula y edita algunos de los campos de los dataGridView de la vista según los colores cargados.
        /// </summary>
        private void calcularTotalesPorColores()
        {
            List<Objeto> colores = new List<Objeto>();
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {
                Objeto color = new Objeto();
                color.Id = dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString().ToLower();
                color.Nombre = dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString().ToLower();
                bool existe = false;
                foreach (Objeto obj in colores)
                {
                    if (obj.Nombre == color.Nombre)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    colores.Add(color);
                }
            }
            List<PedidoMontarTotal> totales = new List<PedidoMontarTotal>();
            foreach (Objeto obj in colores)
            {
                PedidoMontarTotal objColor = new PedidoMontarTotal(0, obj.Id, obj.Nombre, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "");
                for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                {
                    if (dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {
                        objColor.Tiendas += (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                        objColor.Exito += (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
                        objColor.Sao += (dgvInfoConsolidar.Rows[i].Cells[15].Value != null && dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInfoConsolidar.Rows[i].Cells[16].Value != null && dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInfoConsolidar.Rows[i].Cells[17].Value != null && dgvInfoConsolidar.Rows[i].Cells[17].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[17].Value.ToString()) : 0;
                        objColor.Otros += (dgvInfoConsolidar.Rows[i].Cells[18].Value != null && dgvInfoConsolidar.Rows[i].Cells[18].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[18].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInfoConsolidar.Rows[i].Cells[19].Value != null && dgvInfoConsolidar.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[19].Value.ToString()) : 0;
                        objColor.MCalculados += (dgvInfoConsolidar.Rows[i].Cells[21].Value != null && dgvInfoConsolidar.Rows[i].Cells[21].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[21].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInfoConsolidar.Rows[i].Cells[24].Value != null && dgvInfoConsolidar.Rows[i].Cells[24].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[24].Value.ToString()) : 0;
                    }
                }
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvTotalConsolidado.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvTotalConsolidado.Rows.Count; i++)
                    {
                        dgvTotalConsolidado.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvTotalConsolidado.Rows.Count)
                {
                    for (int i = dgvTotalConsolidado.Rows.Count; i < totales.Count; i++)
                    {
                        dgvTotalConsolidado.Rows.Add();
                    }
                }
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvTotalConsolidado.Rows[i].Cells[0].Value = totales[i].CodidoColor;
                    dgvTotalConsolidado.Rows[i].Cells[1].Value = totales[i].DescripcionColor.ToUpper();
                    dgvTotalConsolidado.Rows[i].Cells[12].Value = totales[i].Tiendas.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[13].Value = totales[i].Exito.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[14].Value = totales[i].Cencosud.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[15].Value = totales[i].Sao.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[16].Value = totales[i].ComercioOrg.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[17].Value = totales[i].Rosado.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[18].Value = totales[i].Otros.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[19].Value = totales[i].TotalUnidades.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[20].Value = totales[i].MCalculados.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[21].Value = totales[i].KgCalculados.ToString();
                }
            }
        }

        /// <summary>
        /// Carga la información de la vista.
        /// </summary>
        private void Cargar()
        {
            PedidoAMontar objPedidoPlano = control.getPedidoPlano(IdSolicitudTelas);
            id = objPedidoPlano.Id;
            if (id != 0)
            {

                txtNomTela.Text = objPedidoPlano.Tela.ToString();
                txtDisenador.Text = objPedidoPlano.Disenador.ToString();
                txtEnsayoRef.Text = objPedidoPlano.EnsayoReferencia.ToString();
                txtDesPrenda.Text = objPedidoPlano.DescripcionPrenda.ToString();
                cbxClase.Text = objPedidoPlano.Clase.ToString();
                txtRendimiento.Text = objPedidoPlano.Rendimiento.ToString();
                txtAnalista.Text = objPedidoPlano.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = objPedidoPlano.FechaLlegada.ToString();
                cbxTipoMarcacion.Text = objPedidoPlano.TipoMarcacion.ToString();

                /* Carga Pedido */
                List<TomarDelPedido> listaPedido = control.getPedido(objPedidoPlano.Id);
                if (listaPedido.Count > 0)
                {
                    foreach (TomarDelPedido obj in listaPedido)
                    {
                        dgvPedidos.Rows.Add(obj.NumeroPedido, obj.CodigoColor, obj.Estado, obj.Disponible);
                    }
                }
                /*Carga detalle Información a  Consolidar*/
                List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedidoPlanoInfo(objPedidoPlano.Id);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedidoMontarInformacion obj in listaInfoConsolidar)
                    {
                        dgvInfoConsolidar.Rows.Add(obj.CodigoColor, obj.DescripcionColor,obj.CodigoH1,obj.DescripcionH1,obj.CodigoH2,obj.DescripcionH2,obj.CodigoH3,obj.DescripcionH3, obj.CodigoH4,obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar, obj.KgCalculados);
                    }
                }

                /*Carga detalle Toltal a  Consolidar*/
                List<PedidoMontarTotal> listaTotalConsolidado = control.getPedidoPlanoTotal(objPedidoPlano.Id);
                if (listaTotalConsolidado.Count > 0)
                {
                    foreach (PedidoMontarTotal obj in listaTotalConsolidado)
                    {
                        dgvTotalConsolidado.Rows.Add(obj.CodidoColor, obj.DescripcionColor, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2, obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5,obj.DescripcionH5, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.MCalculados, obj.KgCalculados, obj.TotalPedir, obj.UnidadMedida);
                    }
                }

                /*Esta bandera controla el cargue los dataGridView, es decir, si es true, en método  cargarDgvInfoConsolidar(prmLista) y cargarDgvTotalConsolidar(prmLista),
                 * no se ejecutan, debido a que la información ya esta guardada en la BD. */
                this.bandera = true;

            }
        }
        #endregion

    }
}
