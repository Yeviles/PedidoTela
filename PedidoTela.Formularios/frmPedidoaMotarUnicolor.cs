using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmPedidoaMotarUnicolor : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        List<int> listaIdSolicitudes= new List<int>();
        Validar validacion = new Validar();
        Utilidades utilidades = new Utilidades();
        int  idSolTela,id, consecutivo=0;
        bool bandera = false, noTejer = false;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }

        #endregion

        #region Constructor
        public frmPedidoaMotarUnicolor(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada,int contador, string tipoSolicitud, int idSolTela)
        {
            InitializeComponent();
            control = controlador;
            DetalleSeleccionado = listaSeleccionada;
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            IdSolTela = idSolTela;

        }
        #endregion

        #region Método inicial de Carga
        private void frmPedidoaMotarUnicolor_Load(object sender, EventArgs e)
        {
            Cargarsolicitudes(DetalleSeleccionado);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            Iniciar(DetalleSeleccionado);

            #region ToolTipsText
            dgvInfoConsolidar.Columns["descripColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["codColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["mCalculados"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInfoConsolidar.Columns["maSolicitar"].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInfoConsolidar.Columns["kgCalculados1"].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvTotalConsolidado.Columns["mCalcu"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvTotalConsolidado.Columns["kgCalculados"].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
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
                        if (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInfoConsolidar.Rows[i].Cells[14].Value = utilidades.calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[i].Cells[14].Value = 0;
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
                noTejer = true;
                btnAgregarPedido.Enabled = true;
            }
            else
            {
                noTejer = false;
            }

        }
        
        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex < 10 || e.ColumnIndex == 11 || e.ColumnIndex >=13)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <= 11)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
        
        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10) //Cuando cambia el consumo [10] cambia M Calculados [11] y KG Calculados[14]
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
                            int totalUnidades = int.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[9].Value.ToString());
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = utilidades.calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
                            if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());

                                if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value =utilidades.calcularMSolicitar(mCalculados, mReservados);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);
                                }
                                else
                                {
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else if (e.ColumnIndex == 11) // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
            {
                if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());

                    if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = utilidades.calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                }
            }

            else if (e.ColumnIndex == 12) // cuando cambia M Reservados [12] cambia el M Solicitar [13]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar =utilidades.calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(mSolicitar / rendimiento, 2);
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
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text),2);

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
            if (e.ColumnIndex == 12)
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
                catch (Exception ex)
                {
                    dgvTotalConsolidado.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInfoConsolidar.CurrentRow.Cells[2].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[3].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[4].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[5].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[6].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[7].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[8].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[9].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[11].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[13].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[14].ReadOnly = true;

            if (dgvInfoConsolidar.Columns[e.ColumnIndex].Name == "codColor" || dgvInfoConsolidar.Columns[e.ColumnIndex].Name == "descripColor")
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }

            }
            calcularTotalesPorColores();
        }
        
        private void dgvTotalConsolidado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i=0; i <= 11; i++)
            {
                dgvTotalConsolidado.CurrentRow.Cells[i].ReadOnly = true;
            }
        }
        
        /// <summary>
        /// Boton  confirmar, el  sistema  genera   un  consecutivo   y   la   solicitud     cambia  al   estado   Radicado.  
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
                consecutivo = control.consultarConsecutivoPedido(IdSolTela);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Guarda toda la información de la vista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (noTejer && dgvPedidos.RowCount == 0)
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
                               
                                if (dgvInfoConsolidar.RowCount > 0 && dgvTotalConsolidado.RowCount > 0)
                                {
                                    bool vacio = false;
                                    foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
                                    {
                                        if (row.Cells[11].Value == null || row.Cells[12].Value == null || row.Cells[13].Value == null)
                                        {
                                            vacio = true;
                                        }
                                    }
                                    if (!vacio)
                                    {
                                        //Se obtiene el encabezado de la vista.
                                        PedidoAMontar elemento = ObtenerEncabezado();
                                        if (control.existePedidoUnicolor(IdSolTela))
                                        {
                                            control.actualizarPedidoUnicolor(elemento);
                                        }
                                        else
                                        {
                                            control.addPedUnicolor(elemento);
                                        }

                                        //Consulta el id que se genero cuando se guarda la infromación del encabezado.
                                        id = control.getIdPedUnicolor(IdSolTela);
                                        if (id != 0)
                                        {
                                            control.eliminarPedidoUnicolorTotal(id);
                                            control.eliminarPedidoUnicolorInformacion(id);
                                            control.eliminarPedido(id);

                                            GuardarPedido(id);
                                            GuardarTotalConsolidar(id);
                                            GuardarInformacionConsolidar(id);
                                        }
                                        //Agrega el Consolidado.
                                        AgregarConsolidado();
                                        MessageBox.Show("Pedido Unicolor se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Los campos Kg Calculados, total a Pedir y unidad de Medida Tela deben estar llenos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                               
                            }
                            else
                            {
                                MessageBox.Show("Por favor, Ingrese un valor para Descripción Prenda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, Ingrese un valor para Analista Cortes B.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, Seleccione un valor para Tipo de Marcación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

           }
        }

        /// <summary>
        /// Imprime los datos del consolidado, una vez este se encuentre guardado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PedidoAMontar objPedUnicolor = control.getPedUnicolor(IdSolTela);
            if (objPedUnicolor.Id != 0)
            {
                frmImprimirPedUnicolor frmPedUnicolor = new frmImprimirPedUnicolor(control, IdSolTela);
                frmPedUnicolor.Show();
            }
            else
            {
                MessageBox.Show("El consolidado no ha sido guardado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Cierra la vista.
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
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void Cargarsolicitudes(List<MontajeTelaDetalle> prmLista)
        {
            List<int> listaSolicitudes = new List<int>();
            for (int i = 0; i < prmLista.Count; i++)
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
        /// <param name="lista">Lista de tipo objeto</param>
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
        /// Obtine la información correspondiente al encabezado de la vista.
        /// </summary>
        /// <returns>Retorna un objeto de Tipo PedidoAMontar, representa la información del encabezado.</returns>
        private PedidoAMontar ObtenerEncabezado()
        {
            PedidoAMontar elemento = new PedidoAMontar();
            elemento.Tela = txtNomTela.Text.Trim();
            elemento.Disenador = txtDisenador.Text.Trim();
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.EnsayoReferencia = txtEnsayoRef.Text.Trim();
            elemento.DescripcionPrenda = txtDesPrenda.Text.Trim();
            elemento.Clase = cbxClase.SelectedItem.ToString();
            //elemento.TipoMarcacion = ((Objeto)cbxTipoMarcacion.SelectedItem).Nombre;
            elemento.TipoMarcacion = cbxTipoMarcacion.GetItemText(cbxTipoMarcacion.SelectedItem);
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.AnalistasCortesB = txtAnalista.Text.Trim();
            string fecha = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            elemento.FechaLlegada = fecha;
            elemento.IdSolicitud = IdSolTela;
            return elemento;
        }

        /// <summary>
        /// Guarda la información correspondiente al primer DtaGridView presente en la vista
        /// </summary>
        /// <param name="id">Id del Pedido Unicolor.</param>
        private void GuardarInformacionConsolidar(int id)
        {
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {
                PedidoMontarInformacion detalle = new PedidoMontarInformacion();
                detalle.IdPedidoAMontar = id;
                detalle.CodigoColor = (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionColor = (dgvInfoConsolidar.Rows[i].Cells[1].Value != null && dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() : "";
                detalle.Tiendas = (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.Exito = (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString()) : 0;
                detalle.Cencosud = (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.Sao = (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.Rosado = (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString()) : 0;
                detalle.Otros = (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString()) : 0;
                detalle.Consumo = (dgvInfoConsolidar.Rows[i].Cells[10].Value != null && dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.MCalculados = (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString()) : 0;
                detalle.MReservados = (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.MSolicitar = (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
                control.addPedUnicolorInfoCon(detalle);
            }
        }

        /// <summary>
        ///Se guarda la información del segundo dataGridView (dgvTotalConsolidado).
        /// </summary>
        /// <param name="id">Id del Pedido Unicolor</param>  
        private void GuardarTotalConsolidar(int id )
        {
            for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
            {
                PedidoMontarTotal detalle = new PedidoMontarTotal();
                detalle.IdPedidoAmontar = id;
                detalle.CodidoColor = (dgvTotalConsolidado.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionColor = (dgvTotalConsolidado.Rows[i].Cells[1].Value != null && dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() : "";
                detalle.Tiendas = (dgvTotalConsolidado.Rows[i].Cells[2].Value != null && dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.Exito = (dgvTotalConsolidado.Rows[i].Cells[3].Value != null && dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString()) : 0;
                detalle.Cencosud = (dgvTotalConsolidado.Rows[i].Cells[4].Value != null && dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.Sao = (dgvTotalConsolidado.Rows[i].Cells[5].Value != null && dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvTotalConsolidado.Rows[i].Cells[6].Value != null && dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.Rosado = (dgvTotalConsolidado.Rows[i].Cells[7].Value != null && dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString()) : 0;
                detalle.Otros = (dgvTotalConsolidado.Rows[i].Cells[8].Value != null && dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvTotalConsolidado.Rows[i].Cells[9].Value != null && dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString()) : 0;
                detalle.MCalculados = (dgvTotalConsolidado.Rows[i].Cells[10].Value != null && dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvTotalConsolidado.Rows[i].Cells[11].Value != null && dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString()) : 0;
                detalle.TotalPedir = (dgvTotalConsolidado.Rows[i].Cells[12].Value != null && dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.UnidadMedida = (dgvTotalConsolidado.Rows[i].Cells[13].Value != null && dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() : "";
                control.addPedUnicolorTotalCons(detalle);
            }
        }

        /// <summary>
        /// Guarda la información correspondiente a la sección de Tomar del Pedido.
        /// </summary>
        /// <param name="id">Id del Pedido Cuellos.</param>
        private void GuardarPedido(int id)
        {
            for (int i=0; i<dgvPedidos.RowCount; i++)
            {
                TomarDelPedido pedido = new TomarDelPedido();
                pedido.IdPedidoMontar = id;
                pedido.NumeroPedido = (dgvPedidos.Rows[i].Cells[0].Value.ToString());
                pedido.CodigoColor = (dgvPedidos.Rows[i].Cells[1].Value != null && dgvPedidos.Rows[i].Cells[1].Value.ToString() != "") ? int.Parse(dgvPedidos.Rows[i].Cells[1].Value.ToString()) : 0;
                pedido.Estado = (dgvPedidos.Rows[i].Cells[2].Value != null && dgvPedidos.Rows[i].Cells[2].Value.ToString() != "") ? dgvPedidos.Rows[i].Cells[2].Value.ToString() : "";
                pedido.Disponible = (dgvPedidos.Rows[i].Cells[3].Value != null && dgvPedidos.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvPedidos.Rows[i].Cells[3].Value.ToString()) : 0;
                pedido.TipoPedido = "UNICOLOR";
                control.addPedido(pedido);
            }
        }
        
        /// <summary>
        /// Calcula y edita algunos de los campos de los dataGridView de la vista según los colores cargados. 
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
                        objColor.Tiendas += (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString()) : 0;
                        objColor.Exito += (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString()) : 0;
                        objColor.Sao += (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString()) : 0;
                        objColor.Otros += (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString()) : 0;                 
                        objColor.MCalculados += (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
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
                    dgvTotalConsolidado.Rows[i].Cells[2].Value = totales[i].Tiendas.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[3].Value = totales[i].Exito.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[4].Value = totales[i].Cencosud.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[5].Value = totales[i].Sao.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[6].Value = totales[i].ComercioOrg.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[7].Value = totales[i].Rosado.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[8].Value = totales[i].Otros.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[9].Value = totales[i].TotalUnidades.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[10].Value = totales[i].MCalculados.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = totales[i].KgCalculados.ToString();
                }
            }
            //else
            //{
            //    MessageBox.Show("No existe información sobre su consultafff", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento d e dar clic en Guardar.
        /// </summary>
        private void AgregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < ListaIdSolicitudes.Count; i++)
            {
                control.agregarConsolidado(ListaIdSolicitudes[i], maxConsolidado + 1);
            }

        }

        /// <summary>
        /// Carga la información de la vista. 
        /// </summary>
        private void Cargar()
        {
            PedidoAMontar objPedUnicolor = control.getPedUnicolor(IdSolTela);
            id = objPedUnicolor.Id;
            if (id != 0)
            {   
                txtNomTela.Text = objPedUnicolor.Tela.ToString();
                txtDisenador.Text = objPedUnicolor.Disenador.ToString();
                txtEnsayoRef.Text = objPedUnicolor.EnsayoReferencia.ToString();
                txtDesPrenda.Text = objPedUnicolor.DescripcionPrenda.ToString();
                cbxClase.Text = objPedUnicolor.Clase.ToString();
                cbxTipoMarcacion.Text = objPedUnicolor.TipoMarcacion.ToString();
                txtRendimiento.Text = objPedUnicolor.Rendimiento.ToString();
                txtAnalista.Text = objPedUnicolor.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = objPedUnicolor.FechaLlegada.ToString();

                /* Carga Pedido */
                List<TomarDelPedido> listaPedido = control.getPedido(objPedUnicolor.Id);
                if (listaPedido.Count > 0)
                {
                    foreach (TomarDelPedido obj in listaPedido)
                    {
                        dgvPedidos.Rows.Add(obj.NumeroPedido, obj.CodigoColor, obj.Estado, obj.Disponible);
                    }
                }
                /*Carga detalle Información a  Consolidar*/
                List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedUnicolorInfoCon(objPedUnicolor.Id);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedidoMontarInformacion obj in listaInfoConsolidar)
                    {
                        dgvInfoConsolidar.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar,obj.KgCalculados);
                    }
                }

                /*Carga detalle Toltal a  Consolidar*/
                List<PedidoMontarTotal> listaTotalConsolidado = control.getPedUnicolorTotalCon(objPedUnicolor.Id);
                if (listaTotalConsolidado.Count > 0)
                {
                    foreach (PedidoMontarTotal obj in listaTotalConsolidado)
                    {
                        dgvTotalConsolidado.Rows.Add(obj.CodidoColor, obj.DescripcionColor, obj.Tiendas, obj.Exito,
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
